namespace Bistrotic.Client
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.ApplicationLayer.Helpers;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;
    using Bistrotic.Infrastructure.Client;
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

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
            builder.AddMudBlazorThemeClient();
            builder.AddApplicationLayer();
            builder.Services.AddSingleton<IMenuService, MenuService>();
            builder.Services.AddSingleton<IComponentRendererProvider, ComponentRendererProvider>();
            //builder.Services.AddSingleton<IIconRenderer, LineAwesomeIconRenderer>();
            //builder.Services.AddSingleton<IComponentRenderer, MudBlazorRenderer>();
            await builder.Build().RunAsync();
        }
    }
}