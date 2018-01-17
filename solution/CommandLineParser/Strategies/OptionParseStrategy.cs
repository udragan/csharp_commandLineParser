using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;

namespace com.udragan.csharp.CommandLineParser.Strategies
{
	/// <summary>
	/// Strategy for parsing Option arguments.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Strategies.BaseStrategy" />
	public class OptionParseStrategy : BaseStrategy
	{
		#region BaseStrategy Members

		/// <summary>
		/// Determines whether this instance can parse the specified attribute.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>
		/// True if this instance can parse the specified attribute, otherwise false.
		/// </returns>
		public override bool CanParse(BaseAttribute attribute)
		{
			return attribute is OptionAttribute;
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Parses the value.
		/// </summary>
		/// <param name="mappedProperties">The mapped properties.</param>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <returns>
		/// Parsed value.
		/// </returns>
		protected override object ParseValue(
			IDictionary<BaseAttribute, PropertyInfo> mappedProperties,
			Queue<string> argumentsQueue)
		{
			if (argumentsQueue.Count == 0)
			{
				Console.WriteLine("Option argument specified but no value provided!");
				return null;
			}

			string value = argumentsQueue.Dequeue();

			HashSet<string> argNames = new HashSet<string>(mappedProperties.Keys.Select(x => x.OptionName));

			if (argNames.Contains(value))
			{
				Console.WriteLine("Option argument specified but no value provided!");
				return null;
			}

			return value;
		}

		#endregion
	}
}
