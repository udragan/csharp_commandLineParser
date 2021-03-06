﻿using System.Collections.Generic;
using com.udragan.csharp.CommandLineParser.Arguments;
using com.udragan.csharp.CommandLineParser.Attributes;
using com.udragan.csharp.CommandLineParser.Depencencies;
using com.udragan.csharp.CommandLineParser.Depencencies.Interfaces;

namespace com.udragan.csharp.TestApp.CommandLineArguments
{
	/// <summary>
	/// Example of custom command line arguments.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Options.GenericArguments" />
	public class CustomArguments : GenericArguments
	{
		#region Properties

		/// <summary>
		/// Gets a value of required argument.
		/// </summary>
		[Switch("-s", "Test switch", Required = true)]
		public bool SwitchProperty { get; private set; }

		/// <summary>
		/// Gets a value non required argument.
		/// </summary>
		[Switch("-q", "Q switch")]
		public bool QSwitchProperty { get; private set; }

		/// <summary>
		/// Gets the value option property.
		/// </summary>
		[Option("-o", "Argument with value", DefaultValue = "Default")]
		public string ValueOptionProperty { get; private set; }

		/// <summary>
		/// Gets the option list property.
		/// </summary>
		[OptionList("-p", "Argument list")]
		public IList<string> OptionListProperty { get; private set; }

		/// <summary>
		/// Gets a value of property not considered in parser.
		/// </summary>
		public bool NotSwitchProperty { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomArguments"/> class.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public CustomArguments(string[] args)
			: base(args, new ConsoleLogger())
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomArguments" /> class.
		/// </summary>
		/// <param name="args">The command line arguments.</param>
		/// <param name="logger">The logger.</param>
		public CustomArguments(string[] args, ILogger logger)
			: base(args, logger)
		{ }

		#endregion
	}
}
