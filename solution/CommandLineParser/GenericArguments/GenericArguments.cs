using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;

namespace com.udragan.csharp.CommandLineParser.Arguments
{
	/// <summary>
	/// Base class for generic arguments.
	/// </summary>
	public class GenericArguments
	{
		#region Members

		private IDictionary<SwitchAttribute, PropertyInfo> _mappedProps = new Dictionary<SwitchAttribute, PropertyInfo>();

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
			_mappedProps = ExtractClassArgumentProperties();

			if (args.Contains(HelpSwitchAttribute.OptionName))
			{
				DisplayHelp();
				return;
			}

			ProcessArguments(args);
		}

		#endregion

		#region Private methods

		[Pure]
		private IDictionary<SwitchAttribute, PropertyInfo> ExtractClassArgumentProperties()
		{
			IDictionary<SwitchAttribute, PropertyInfo> result = new Dictionary<SwitchAttribute, PropertyInfo>();

			PropertyInfo[] switchArgumentProperties = this.GetType()
				.GetProperties()
				.Where(x => x.IsDefined(typeof(SwitchAttribute)))
				.ToArray();

			foreach (PropertyInfo item in switchArgumentProperties)
			{
				SwitchAttribute customAttribute = (SwitchAttribute)item.GetCustomAttribute(typeof(SwitchAttribute));
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

				SwitchAttribute attribute = _mappedProps.Keys
					.FirstOrDefault(x => x.OptionName.Equals(argument, StringComparison.OrdinalIgnoreCase));

				if (attribute != null)
				{
					PropertyInfo propertyInfo = _mappedProps[attribute];
					propertyInfo.SetValue(this, true);
				}
			}
		}

		[Pure]
		private void DisplayHelp()
		{
			int maxArgumentLength = _mappedProps.Keys.Max(x => x.OptionName.Length);

			foreach (PropertyInfo item in _mappedProps.Values)
			{
				SwitchAttribute customAttribute = (SwitchAttribute)item.GetCustomAttributes(typeof(SwitchAttribute)).First();

				Console.Write(customAttribute.OptionName.PadRight(maxArgumentLength + 2));
				Console.Write(customAttribute.Help);
				Console.WriteLine(customAttribute.Required ? " <Required>" : string.Empty);
			}
		}

		#endregion
	}
}
