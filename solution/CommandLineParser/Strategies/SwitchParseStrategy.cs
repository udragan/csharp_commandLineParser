using System.Collections.Generic;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;
using com.udragan.csharp.CommandLineParser.Strategies.Interfaces;

namespace com.udragan.csharp.CommandLineParser.Strategies
{
	/// <summary>
	/// Strategy for parsing Switch arguments.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Strategies.IParseStrategy" />
	public class SwitchParseStrategy : IParseStrategy
	{
		#region IParseStrategy Members

		/// <summary>
		/// Parses the specified mapped properties.
		/// </summary>
		/// <param name="mappedProperties">The mapped properties.</param>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <returns>
		/// Parsed value.
		/// </returns>
		public object Parse(IDictionary<BaseAttribute, PropertyInfo> mappedProperties, Queue<string> argumentsQueue)
		{
			return true;
		}

		/// <summary>
		/// Determines whether this instance can parse the specified attribute.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>
		/// True if this instance can parse the specified attribute, otherwise false.
		/// </returns>
		public bool CanParse(BaseAttribute attribute)
		{
			return attribute is SwitchAttribute;
		}

		#endregion
	}
}
