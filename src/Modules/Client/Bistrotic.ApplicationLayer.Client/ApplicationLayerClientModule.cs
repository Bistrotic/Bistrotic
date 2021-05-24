namespace Bistrotic.ApplicationLayer.Client
{
    using Bistrotic.ApplicationLayer.Services;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationLayerClientModule : ClientModule
    {
        public ApplicationLayerClientModule(
            IWebAssemblyHostEnvironment hostEnvironment,
            string clientName,
            string serverApiName,
            ClientMode clientMode)
            : base(hostEnvironment, clientName, serverApiName, clientMode)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApplicationNameService, ApplicationLayerService>();
        }
    }
}