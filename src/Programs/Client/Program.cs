namespace Bistrotic.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Bistrotic.BlazorClient;
    using Bistrotic.Infrastructure;

    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBistroticClient(builder.HostEnvironment, typeof(Program).Namespace ?? string.Empty, BistroticConstants.ServerApiName);
            // builder.Services.AddHttpClient("Bistrotic.ServerAPI", client => client.BaseAddress =
            // new Uri(builder.HostEnvironment.BaseAddress))
            // .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            // builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Bistrotic.ServerAPI"));

            builder.Logging.AddBistroticClient();
            await builder.Build().RunAsync();
        }
    }
}