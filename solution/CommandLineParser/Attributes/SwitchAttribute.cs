using System;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	/// <summary>
	/// Switch attribute representing true/false command line option.
	/// </summary>
	/// <seealso cref="BaseAttribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class SwitchAttribute : BaseAttribute
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SwitchAttribute"/> class.
		/// </summary>
		/// <param optionName="optionName">The option name.</param>
		/// <param optionName="help">The help text.</param>
		public SwitchAttribute(string optionName, string help)
			: base(optionName, help)
		{ }

		#endregion
	}
}
