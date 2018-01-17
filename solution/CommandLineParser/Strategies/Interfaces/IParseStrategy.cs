using System.Collections.Generic;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Arguments;
using com.udragan.csharp.CommandLineParser.Attributes;

namespace com.udragan.csharp.CommandLineParser.Strategies.Interfaces
{
	/// <summary>
	/// Common interface for all parse strategies.
	/// </summary>
	public interface IParseStrategy
	{
		/// <summary>
		/// Parses the specified mapped properties.
		/// </summary>
		/// <param name="genericArguments">The generic arguments class.</param>
		/// <param name="mappedProperties">The mapped properties.</param>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <param name="attribute">The attribute.</param>
		void Parse(GenericArguments genericArguments,
			IDictionary<BaseAttribute, PropertyInfo> mappedProperties,
			Queue<string> argumentsQueue,
			BaseAttribute attribute);

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
