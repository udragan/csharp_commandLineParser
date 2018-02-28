using System;
using System.Collections.Generic;

namespace com.udragan.csharp.CommandLineParser.Attributes
{
	/// <summary>
	/// OptionList attribute representing a list of values command line option.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Attributes.BaseAttribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class OptionListAttribute : BaseAttribute
	{
		#region Members

		private IList<string> _defaultValue;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionListAttribute"/> class.
		/// </summary>
		/// <param optionName="optionName">The option name.</param>
		/// <param optionName="help">The help text.</param>
		public OptionListAttribute(string optionName, string help)
			: base(optionName, help)
		{
			_defaultValue = new List<string>();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		public IList<string> DefaultValue
		{
			get { return _defaultValue; }
			set { _defaultValue = value; }
		}

		#endregion
	}
}
