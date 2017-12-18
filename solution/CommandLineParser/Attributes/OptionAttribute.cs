using System;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	/// <summary>
	/// Option attribute representing value command line option.
	/// </summary>
	/// <seealso cref="BaseAttribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class OptionAttribute : BaseAttribute
	{
		#region Members

		private string _defaultValue;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionAttribute"/> class.
		/// </summary>
		/// <param optionName="optionName">The option name.</param>
		/// <param optionName="help">The help text.</param>
		public OptionAttribute(string optionName, string help)
			: base(optionName, help)
		{ }

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		public string DefaultValue
		{
			get { return _defaultValue; }
			set { _defaultValue = value; }
		}

		#endregion
	}
}
