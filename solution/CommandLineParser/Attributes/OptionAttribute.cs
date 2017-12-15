using System;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	/// <summary>
	/// Option attribute representing value command line option.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class OptionAttribute : Attribute
	{
		#region Members

		private string _optionName;
		private string _defaultValue;
		private string _help;
		private bool _required;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionAttribute"/> class.
		/// </summary>
		/// <param optionName="optionName">The option name.</param>
		/// <param optionName="help">The help text.</param>
		public OptionAttribute(string optionName, string help)
		{
			_optionName = optionName;
			_help = help;
			_required = false;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the argument option name.
		/// </summary>
		public string OptionName
		{
			get { return _optionName; }
		}

		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		public string DefaultValue
		{
			get { return _defaultValue; }
			set { _defaultValue = value; }
		}

		/// <summary>
		/// Gets the help text.
		/// </summary>
		public string Help
		{
			get { return _help; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="OptionAttribute" /> is required.
		/// </summary>
		public bool Required
		{
			get { return _required; }
			set { _required = value; }
		}

		#endregion
	}
}
