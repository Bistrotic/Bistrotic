namespace Bistrotic.ApplicationLayer.Client
{
    using Bistrotic.ApplicationLayer.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationLayerClient
    {
        public static void AddApplicationLayerClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddTransient<IApplicationNameService, ApplicationLayerService>();
        }
    }
}