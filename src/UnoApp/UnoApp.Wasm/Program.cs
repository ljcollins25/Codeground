using System;
using Windows.UI.Xaml;

namespace UnoApp.Wasm
{
	public class Program
	{
		private static App _app;

		static int Main(string[] args)
		{
			Console.WriteLine("Starting");
			Windows.UI.Xaml.Application.Start(_ => _app = new App());

			Console.WriteLine("Finished");


			return 0;
		}
	}
}
