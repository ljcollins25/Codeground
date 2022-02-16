using BlazorWorker.BackgroundServiceFactory;
using BlazorWorker.Core;
using BlazorWorker.WorkerBackgroundService;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Hosting;

namespace BlazorConsoleApp
{
    public record AppService(IWorkerFactory WorkerFactory) : IHostedService
    {
        public IWorker Worker { get; private set; }

        //public AppService(IWorkerFactory workerFactory)
        //{
        //}

        public IWorkerBackgroundService<MyCPUIntensiveService> Service { get; private set; }

        public Task OnAfterRenderAsync()
        {
            return Task.CompletedTask;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started AppService");
            if (!cancellationToken.IsCancellationRequested)
            {
                return;
            }
            Worker = await WorkerFactory.CreateAsync();
            Service = await Worker.CreateBackgroundServiceAsync<MyCPUIntensiveService>();

            var result = await Service.RunAsync(s => s.MyMethod(10));

            var result2 = await Service.RunAsync(s => s.MyMethod(22));

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public class MyCPUIntensiveService
    {
        public int MyMethod(int parameter)
        {
            Console.WriteLine($"Hello from CPU Service: {parameter}");
            return parameter + 1;
        }
    }
}
