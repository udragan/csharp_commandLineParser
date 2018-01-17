using System.Collections.Generic;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;

namespace com.udragan.csharp.CommandLineParser.Strategies
{
	/// <summary>
	/// Strategy for parsing Switch arguments.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Strategies.BaseStrategy" />
	public class SwitchParseStrategy : BaseStrategy
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
			return attribute is SwitchAttribute;
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
			return true;
		}

		#endregion
	}
}
