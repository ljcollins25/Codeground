using BlazorConsoleApp;
using BlazorWorker.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Hosting;
using System.Reflection;

Console.WriteLine("Start application");


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

var messageProxy = (MessageProxy)DispatchProxy.Create<ICodex, MessageProxy>();

messageProxy.SetCodex(new TestCodex(100));

var codex = (ICodex)messageProxy;

var result = await codex.SearchAsync(13);
Console.WriteLine($"Log result: {result}");


host.Build().RunAsync();

//await builder.Build().RunAsync();
