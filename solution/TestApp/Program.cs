using System;
using com.udragan.csharp.TestApp.CommandLineArguments;

namespace com.udragan.csharp.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			CustomArguments co = new CustomArguments(args);

			if (co.IsValid)
			{
				co.DisplayOptions();
			}

			Console.ReadLine();
		}
	}
}
