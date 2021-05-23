namespace Bistrotic.Client
{
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;
    using Bistrotic.Infrastructure.Client;
    using Bistrotic.Infrastructure.VisualComponents.Themes;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using MudBlazor.Services;

    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

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
            builder.Services.AddMudServices();
            builder.Logging.AddBistroticClient();

            builder.Services.AddSingleton<IMenuService, MenuService>();
            builder.Services.AddSingleton<IIconRenderer, LineAwesomeIconRenderer>();
            builder.Services.AddSingleton<IComponentRenderer, MudBlazorRenderer>();
            await builder.Build().RunAsync();
            Console.WriteLine("Main ended");
        }
    }
}