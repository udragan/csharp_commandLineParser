using System.Collections.Generic;
using System.Reflection;
using com.udragan.csharp.CommandLineParser.Arguments;
using com.udragan.csharp.CommandLineParser.Attributes;
using com.udragan.csharp.CommandLineParser.Strategies.Interfaces;

namespace com.udragan.csharp.CommandLineParser.Strategies
{
	/// <summary>
	/// Base implementation of IParseStrategy.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Strategies.Interfaces.IParseStrategy" />
	public abstract class BaseStrategy : IParseStrategy
	{
		#region IParseStrategy

		/// <summary>
		/// Parses the specified generic arguments class.
		/// </summary>
		/// <param name="genericArgumentsClass">The generic arguments class.</param>
		/// <param name="mappedProperties">The mapped properties.</param>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <param name="attribute">The attribute.</param>
		public void Parse(GenericArguments genericArgumentsClass,
			IDictionary<BaseAttribute, PropertyInfo> mappedProperties,
			Queue<string> argumentsQueue,
			BaseAttribute attribute)
		{
			object value = ParseValue(mappedProperties, argumentsQueue);
			SetValue(genericArgumentsClass, mappedProperties[attribute], value);
		}

		/// <summary>
		/// Determines whether this instance can parse the specified attribute.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns>
		/// True if this instance can parse the specified attribute, otherwise false.
		/// </returns>
		public virtual bool CanParse(BaseAttribute attribute)
		{
			return false;
		}

		#endregion

		/// <summary>
		/// Parses the value.
		/// </summary>
		/// <param name="mappedProperties">The mapped properties.</param>
		/// <param name="argumentsQueue">The arguments queue.</param>
		/// <returns>Parsed value.</returns>
		protected abstract object ParseValue(
			IDictionary<BaseAttribute, PropertyInfo> mappedProperties,
			Queue<string> argumentsQueue);

		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="genericArguments">The generic arguments.</param>
		/// <param name="propertyInfo">The property information.</param>
		/// <param name="value">The value.</param>
		protected virtual void SetValue(
			GenericArguments genericArguments,
			PropertyInfo propertyInfo,
			object value)
		{
			propertyInfo.SetValue(genericArguments, value);
		}
	}
}
