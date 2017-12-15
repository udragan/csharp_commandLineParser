using System;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	/// <summary>
	/// Base attribute.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	public abstract class BaseAttribute : Attribute
	{
		#region Members

		private string _optionName;
		private string _help;
		private bool _required;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseAttribute"/> class.
		/// </summary>
		/// <param optionName="optionName">The option name.</param>
		/// <param optionName="help">The help text.</param>
		public BaseAttribute(string optionName, string help)
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
		/// Gets or sets a value indicating whether this argument is required.
		/// </summary>
		public bool Required
		{
			get { return _required; }
			set { _required = value; }
		}

		#endregion

		#region Overrides

		public override int GetHashCode()
		{
			return _optionName.GetHashCode();
		}

		#endregion
	}
}
