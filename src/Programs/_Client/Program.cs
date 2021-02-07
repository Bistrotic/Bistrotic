namespace Bistrotic.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Bistrotic.BlazorClient;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Configuration;

    public class Program // : ClientProgram<App>
    {
        public static WebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = WebAssemblyHostBuilder
                .CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddOptions();

            builder.Logging.AddConfiguration();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            return builder;
        }

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }
    }
}