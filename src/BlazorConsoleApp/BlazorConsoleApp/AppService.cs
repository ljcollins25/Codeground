using Microsoft.AspNetCore.Components;

namespace BlazorConsoleApp
{
    public class AppService : IHandleAfterRender
    {
        public AppService()
        {

        }

        public Task OnAfterRenderAsync()
        {
            return Task.CompletedTask;
        }
    }

    public class MyCPUIntensiveService
    {
        public int MyMethod(int parameter)
        {
            Console.WriteLine(parameter);
            return parameter + 1;
        }
    }
}
