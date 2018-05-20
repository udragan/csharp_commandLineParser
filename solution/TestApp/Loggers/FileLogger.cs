using System;
using System.IO;
using com.udragan.csharp.CommandLineParser.Depencencies.Interfaces;

namespace com.udragan.csharp.TestApp.Loggers
{
	/// <summary>
	/// Logger that writes to file.
	/// </summary>
	/// <seealso cref="com.udragan.csharp.CommandLineParser.Depencencies.Interfaces.ILogger" />
	public class FileLogger : ILogger
	{
		#region Members

		private readonly string _fileName;
		private readonly string _filePath;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="FileLogger"/> class.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		public FileLogger(string fileName)
			: this(fileName, Directory.GetCurrentDirectory())
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="FileLogger"/> class.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		/// <exception cref="System.IO.DirectoryNotFoundException"></exception>
		public FileLogger(string fileName, string filePath)
		{
			string path = Path.GetFullPath(filePath);

			if (!Directory.Exists(path))
			{
				throw new DirectoryNotFoundException();
			}

			_fileName = fileName;
			_filePath = filePath;

			using (StreamWriter fileWriter = File.AppendText(Path.Combine(_filePath, _fileName)))
			{
				fileWriter.WriteLine("{0} - FileLogger initialized.", DateTime.UtcNow);
			}
		}

		#endregion

		#region ILogger Members

		/// <summary>
		/// Logs the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public void Log(string message)
		{
			using (StreamWriter fileWriter = File.AppendText(Path.Combine(_filePath, _fileName)))
			{
				fileWriter.WriteLine(message);
			}
		}

		#endregion
	}
}
