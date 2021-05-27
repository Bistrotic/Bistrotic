namespace Bistrotic.Client
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;
    using Bistrotic.Infrastructure.Client;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;


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

            builder.Services.AddBistroticClient(builder.HostEnvironment, typeof(Program).Namespace ?? string.Empty, BistroticConstants.ServerApiName);
            builder.Logging.AddBistroticClient();

            builder.Services.AddSingleton<IMenuService, MenuService>();
            //builder.Services.AddSingleton<IIconRenderer, LineAwesomeIconRenderer>();
            //builder.Services.AddSingleton<IComponentRenderer, MudBlazorRenderer>();
            await builder.Build().RunAsync();
            Console.WriteLine("Main ended");
        }
    }
}