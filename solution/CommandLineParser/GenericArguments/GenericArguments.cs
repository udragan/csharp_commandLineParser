using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;
using com.udragan.csharp.CommandLineParser.Depencencies.Interfaces;
using com.udragan.csharp.CommandLineParser.Extensions;
using com.udragan.csharp.CommandLineParser.Strategies;
using com.udragan.csharp.CommandLineParser.Strategies.Interfaces;

namespace com.udragan.csharp.CommandLineParser.Arguments
{
	/// <summary>
	/// Base class for generic arguments.
	/// </summary>
	public abstract class GenericArguments
	{
		#region Members

		private readonly ILogger _logger;

		private IList<IParseStrategy> _parseStrategies = new List<IParseStrategy>();
		private IDictionary<BaseAttribute, PropertyInfo> _mappedProperties = new Dictionary<BaseAttribute, PropertyInfo>();
		private HashSet<string> _mandatoryArguments = new HashSet<string>();

		private SwitchAttribute HelpSwitchAttribute
		{
			get
			{
				return (SwitchAttribute)this.GetType()
					.GetProperty("Help")
					.GetCustomAttribute(typeof(SwitchAttribute));
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="GenericArguments"/> is help.
		/// </summary>
		[Switch("/h", "Display help.")]
		public virtual bool Help { get; set; }

		/// <summary>
		/// Returns true if all mandatory arguments are provided, otherwise false.
		/// </summary>
		public bool IsValid
		{
			get { return _mandatoryArguments.Count == 0; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericArguments" /> class.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <param name="logger">The logger.</param>
		public GenericArguments(string[] args, ILogger logger)
		{
			_logger = logger;
			_parseStrategies.Add(new SwitchParseStrategy());
			_parseStrategies.Add(new OptionParseStrategy());
			_parseStrategies.Add(new OptionListParseStrategy());

			_mappedProperties = ExtractClassArgumentProperties();
			_mandatoryArguments = new HashSet<string>(
				_mappedProperties
				.Where(x => x.Key.Required)
				.Select(x => x.Key.OptionName)
				.ToList());

			if (args.Contains(HelpSwitchAttribute.OptionName))
			{
				DisplayHelp();
				return;
			}

			ProcessArguments(args);

			if (!IsValid)
			{
				DisplayHelp();
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Displays the options.
		/// </summary>
		[Pure]
		public void DisplayOptions()
		{
			if (!_mappedProperties.Any())
			{
				_logger.Log("No options available.");
				return;
			}

			int maxArgumentLength = _mappedProperties.Keys.Max(x => x.OptionName.Length);

			//TODO: convert to factory.
			foreach (KeyValuePair<BaseAttribute, PropertyInfo> item in _mappedProperties)
			{
				string message = item.Key.OptionName.PadRight(maxArgumentLength + 2) +
					item.Value.ToString(this) ?? ((OptionAttribute)item.Key).DefaultValue;
				_logger.Log(message);
			}
		}

		#endregion

		#region Private methods

		[Pure]
		private IDictionary<BaseAttribute, PropertyInfo> ExtractClassArgumentProperties()
		{
			IDictionary<BaseAttribute, PropertyInfo> result = new Dictionary<BaseAttribute, PropertyInfo>();

			PropertyInfo[] argumentProperties = this.GetType()
				.GetProperties()
				.Where(x => x.IsDefined(typeof(BaseAttribute)))
				.ToArray();

			foreach (PropertyInfo item in argumentProperties)
			{
				BaseAttribute customAttribute = (BaseAttribute)item.GetCustomAttribute(typeof(BaseAttribute));
				result[customAttribute] = item;
			}

			return result;
		}

		[Pure]
		private void DisplayHelp()
		{
			int maxArgumentLength = _mappedProperties.Keys.Max(x => x.OptionName.Length);

			foreach (PropertyInfo item in _mappedProperties.Values)
			{
				BaseAttribute customAttribute = (BaseAttribute)item.GetCustomAttributes(typeof(BaseAttribute)).First();

				string message = customAttribute.OptionName.PadRight(maxArgumentLength + 2) +
					customAttribute.Help +
					(customAttribute.Required ? " <Required>" : string.Empty);
				_logger.Log(message);
			}
		}

		private void ProcessArguments(string[] args)
		{
			Queue<string> queue = new Queue<string>(args);

			while (queue.Count > 0)
			{
				string argument = queue.Dequeue();

				BaseAttribute attribute = _mappedProperties.Keys
					.FirstOrDefault(x => x.OptionName.Equals(argument, StringComparison.OrdinalIgnoreCase));

				if (attribute == null)
				{
					string message = string.Format("No attribute registered: {0}", argument);
					_logger.Log(message);

					continue;
				}

				IParseStrategy strategy = _parseStrategies.SingleOrDefault(x => x.CanParse(attribute));

				if (strategy == null)
				{
					string message = string.Format("No strategy can parse argument: {0} of type: {1}", argument, attribute.GetType().GetName());
					_logger.Log(message);

					continue;
				}

				strategy.Parse(this, _mappedProperties, queue, attribute);

				_mandatoryArguments.Remove(attribute.OptionName);
			}
		}

		#endregion
	}
}
