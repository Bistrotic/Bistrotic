namespace Bistrotic.Client
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            if (builder.HostEnvironment.IsDevelopment())
            {
                Console.WriteLine("Blazor client strating in development mode.");
            }
            else
            {
                Console.WriteLine("Blazor client strating in production mode.");
            }
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBistroticClient(builder.HostEnvironment, typeof(Program).Namespace ?? string.Empty, BistroticConstants.ServerApiName);

            builder.Logging.AddBistroticClient();
            await builder.Build().RunAsync();
            Console.WriteLine("Main ended");
        }
    }
}