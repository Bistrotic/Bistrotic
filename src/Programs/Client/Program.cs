namespace Bistrotic.Client
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

    public static class Program
    {
        public static Task Main(string[] args)
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
            return builder.Build().RunAsync();
        }
    }
}