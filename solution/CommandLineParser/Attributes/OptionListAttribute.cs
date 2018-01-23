using System;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class OptionListAttribute : BaseAttribute
	{
		#region Constructors

		public OptionListAttribute(string optionName, string help)
			: base(optionName, help)
		{ }

		#endregion
	}
}
