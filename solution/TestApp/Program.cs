using System;
using com.udragan.csharp.TestApp.CommandLineArguments;
using com.udragan.csharp.TestApp.Loggers;

namespace com.udragan.csharp.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			FileLogger fl = new FileLogger("bla.txt");

			CustomArguments co = new CustomArguments(args);

			if (co.IsValid)
			{
				co.DisplayOptions();
			}

			Console.ReadLine();
		}
	}
}
