using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;
using com.udragan.csharp.CommandLineParser.Strategies.Interfaces;

namespace com.udragan.csharp.CommandLineParser.Strategies
{
	/// <summary>
	/// Strategy for parsing Option arguments.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Strategies.IParseStrategy" />
	public class OptionParseStrategy : IParseStrategy
	{
		#region IParseStrategy Members

		/// <summary>
		/// Parses the specified mapped properties.
		/// </summary>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <returns>
		/// Parsed value.
		/// </returns>
		public object Parse(IDictionary<BaseAttribute, PropertyInfo> mappedProperties, Queue<string> argumentsQueue)
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

		/// <summary>
		/// Determines whether this instance can parse the specified attribute.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>
		/// True if this instance can parse the specified attribute, otherwise false.
		/// </returns>
		public bool CanParse(BaseAttribute attribute)
		{
			return attribute is OptionAttribute;
		}

		#endregion
	}
}
