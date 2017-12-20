using System.Collections.Generic;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Attributes;

namespace com.udragan.csharp.CommandLineParser.Strategies
{
	/// <summary>
	/// Common interface for all parse strategies.
	/// </summary>
	public interface IParseStrategy
	{
		/// <summary>
		/// Parses the specified mapped properties.
		/// </summary>
		/// <param name="mappedProperties">The mapped properties.</param>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <returns>
		/// Parsed value.
		/// </returns>
		object Parse(IDictionary<BaseAttribute, PropertyInfo> mappedProperties,
			Queue<string> argumentsQueue);

		/// <summary>
		/// Determines whether this instance can parse the specified attribute.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>
		/// True if this instance can parse the specified attribute, otherwise false.
		/// </returns>
		bool CanParse(BaseAttribute attribute);
	}
}
