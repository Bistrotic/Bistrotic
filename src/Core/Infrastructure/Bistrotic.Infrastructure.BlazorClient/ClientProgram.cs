namespace Bistrotic.Client
{
    using System;
    using System.Net.Http;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging.Configuration;

    public class ClientProgram<TApp> where TApp : IComponent
    {
        public static WebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = WebAssemblyHostBuilder
                .CreateDefault(args);
            builder.RootComponents.Add<TApp>("#app");
            builder.Services.AddOptions();

            builder.Logging.AddConfiguration();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            return builder;
        }
    }
}