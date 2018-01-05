namespace com.udragan.csharp.CommandLineParser.Depencencies.Interfaces
{
	/// <summary>
	/// Interface for generic logger.
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Logs the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		void Log(string message);
	}
}
