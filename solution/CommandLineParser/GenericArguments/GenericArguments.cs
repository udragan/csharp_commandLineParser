using System;
using System.Collections.Generic;
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

		private IDictionary<string, PropertyInfo> mappedProps = new Dictionary<string, PropertyInfo>();

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
			PropertyInfo[] switchArgumentProperties = this.GetType()
				.GetProperties()
				.Where(x => x.IsDefined(typeof(SwitchAttribute)))
				.ToArray();

			foreach (PropertyInfo item in switchArgumentProperties)
			{
				SwitchAttribute customAttribute = (SwitchAttribute)item.GetCustomAttribute(typeof(SwitchAttribute));
				mappedProps[customAttribute.OptionName] = item;
			}

			if (args.Contains(HelpSwitchAttribute.OptionName))
			{
				DisplayHelp();
				return;
			}
		}

		#endregion

		#region Private methods

		private void DisplayHelp()
		{
			int maxArgumentLength = mappedProps.Keys.Max(x => x.Length);

			foreach (PropertyInfo item in mappedProps.Values)
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
