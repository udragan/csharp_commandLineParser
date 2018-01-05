using System;
using com.udragan.csharp.CommandLineParser.Depencencies.Interfaces;

namespace com.udragan.csharp.CommandLineParser.Depencencies
{
	/// <summary>
	/// Default logger that writes to console.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Depencencies.Interfaces.ILogger" />
	public class ConsoleLogger : ILogger
	{
		#region ILogger Members

		/// <summary>
		/// Logs the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public void Log(string message)
		{
			Console.WriteLine(message);
		}

		#endregion
	}
}
