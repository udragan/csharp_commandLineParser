using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.udragan.csharp.CommandLineParser.Extensions
{
	/// <summary>
	/// PropertyInfo extensions.
	/// </summary>
	public static class PropertyInfoExtensions
	{
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="parent">The parent object that the property belongs to.</param>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public static string ToString(this PropertyInfo value, object parent)
		{
			Type propertyType = value.PropertyType;

			var val = value.GetValue(parent);

			if (val == null)
			{
				return null;
			}

			if (propertyType == typeof(IList<string>))
			{
				return string.Join(Environment.NewLine + "\t", val as IList<string>);
			}

			return val.ToString();
		}
	}
}
