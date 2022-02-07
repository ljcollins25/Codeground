using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UnoApp;
using System;
using Windows.UI.Xaml;

namespace UnoBlazorApp
{
	public class Program
	{
		private static App _app;

		static async Task Main(string[] args)
		{
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
			Console.WriteLine("Hello5");

			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			Console.WriteLine("starting app");

			try
			{
				Windows.UI.Xaml.Application.Start(_ => _app = new App());
			}
			catch (Exception ex) when (CheckException(ex))
            {

            }

			Console.WriteLine("started app");

			//await builder.Build().RunAsync();

			Console.WriteLine("finished run async");

		}

        private static void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
			var exception = e.Exception;
			var exceptionText = e.ToString();
        }

        private static bool CheckException(Exception ex)
        {
			return false;
        }
    }
}

