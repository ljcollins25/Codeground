using BlazorConsoleApp;
using BlazorWorker.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

Console.WriteLine("Start application");


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<AppService>();
builder.Services.AddWorkerFactory();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
