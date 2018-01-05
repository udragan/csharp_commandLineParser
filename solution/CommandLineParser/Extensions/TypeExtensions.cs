using System;
using System.Linq;

namespace com.udragan.csharp.CommandLineParser.Extensions
{
	/// <summary>
	/// Type extensions.
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Gets the name of the type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>Type name.</returns>
		public static string GetName(this Type type)
		{
			return type != null ?
				type.ToString().Split('.').Last() :
				string.Empty;
		}
	}
}
