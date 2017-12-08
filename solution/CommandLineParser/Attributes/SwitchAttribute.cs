using System;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	/// <summary>
	/// Switch attribute representing true/false command line option.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class SwitchAttribute : Attribute
	{
		#region Members

		private string _optionName;
		private string _help;
		private bool _required;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SwitchAttribute"/> class.
		/// </summary>
		/// <param optionName="optionName">The option name.</param>
		/// <param optionName="help">The help text.</param>
		public SwitchAttribute(string optionName, string help)
		{
			_optionName = optionName;
			_help = help;
			_required = false;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the switch option name.
		/// </summary>
		public string OptionName
		{
			get { return _optionName; }
		}

		/// <summary>
		/// Gets the help text.
		/// </summary>
		public string Help
		{
			get { return _help; }
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="SwitchAttribute"/> is required.
		/// </summary>
		public bool Required
		{
			get { return _required; }
		}

		#endregion
	}
}
