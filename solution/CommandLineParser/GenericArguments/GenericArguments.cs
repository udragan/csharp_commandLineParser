using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;
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

		private IDictionary<BaseAttribute, PropertyInfo> _mappedProperties = new Dictionary<BaseAttribute, PropertyInfo>();
		private IList<IParseStrategy> _parseStrategies = new List<IParseStrategy>();

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="GenericArguments"/> is help.
		/// </summary>
		[Switch("/h", "Display help.")]
		public virtual bool Help { get; set; }

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

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericArguments"/> class.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public GenericArguments(string[] args)
		{
			_parseStrategies.Add(new SwitchParseStrategy());
			_parseStrategies.Add(new OptionParseStrategy());

			_mappedProperties = ExtractClassArgumentProperties();

			if (args.Contains(HelpSwitchAttribute.OptionName))
			{
				DisplayHelp();
				return;
			}

			ProcessArguments(args);
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
				Console.WriteLine("No options available.");
				return;
			}

			int maxArgumentLength = _mappedProperties.Values.Max(x => x.Name.Length);

			//TODO: convert to factory.
			foreach (KeyValuePair<BaseAttribute, PropertyInfo> item in _mappedProperties)
			{
				Console.Write(item.Value.Name.PadRight(maxArgumentLength + 2));
				Console.WriteLine(item.Value.GetValue(this) ?? ((OptionAttribute)item.Key).DefaultValue);
			}
		}

		#endregion

		#region Private methods

		[Pure]
		private IDictionary<BaseAttribute, PropertyInfo> ExtractClassArgumentProperties()
		{
			IDictionary<BaseAttribute, PropertyInfo> result = new Dictionary<BaseAttribute, PropertyInfo>();

			PropertyInfo[] switchArgumentProperties = this.GetType()
				.GetProperties()
				.Where(x => x.IsDefined(typeof(BaseAttribute)))
				.ToArray();

			foreach (PropertyInfo item in switchArgumentProperties)
			{
				BaseAttribute customAttribute = (BaseAttribute)item.GetCustomAttribute(typeof(BaseAttribute));
				result[customAttribute] = item;
			}

			return result;
		}

		private void ProcessArguments(string[] args)
		{
			Queue<string> queue = new Queue<string>(args);

			while (queue.Count > 0)
			{
				string argument = queue.Dequeue();

				BaseAttribute attribute = _mappedProperties.Keys
					.FirstOrDefault(x => x.OptionName.Equals(argument, StringComparison.OrdinalIgnoreCase));
				IParseStrategy strategy = _parseStrategies.SingleOrDefault(x => x.CanParse(attribute));

				if (strategy != null)
				{
					object value = strategy.Parse(_mappedProperties, queue);

					if (value != null)
					{
						PropertyInfo propertyInfo = _mappedProperties[attribute];
						propertyInfo.SetValue(this, value);
					}
				}
				else
				{
					Console.WriteLine("No strategy can parse argument: {0} of type: {1}", argument, attribute.GetType().GetName());
				}
			}
		}

		[Pure]
		private void DisplayHelp()
		{
			int maxArgumentLength = _mappedProperties.Keys.Max(x => x.OptionName.Length);

			foreach (PropertyInfo item in _mappedProperties.Values)
			{
				BaseAttribute customAttribute = (BaseAttribute)item.GetCustomAttributes(typeof(BaseAttribute)).First();

				Console.Write(customAttribute.OptionName.PadRight(maxArgumentLength + 2));
				Console.Write(customAttribute.Help);
				Console.WriteLine(customAttribute.Required ? " <Required>" : string.Empty);
			}
		}

		#endregion
	}
}
