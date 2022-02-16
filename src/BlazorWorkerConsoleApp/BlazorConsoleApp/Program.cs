using BlazorConsoleApp;
using BlazorWorker.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Start application2");

var host = new HostBuilder();
var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddSingleton<AppService>();
//builder.Services

host.ConfigureServices(sc =>
{
    foreach (var service in builder.Services)
    {
        sc.Add(service);
    }

    sc.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    sc.AddWorkerFactory();
    sc.AddHostedService<AppService>();
});

host.Build().RunAsync();

//await builder.Build().RunAsync();
