namespace Bistrotic.FastTheme.Client
{
    using Bistrotic.FastTheme.Services;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class FastThemeClientModule : ClientModule
    {
        public FastThemeClientModule(
            IWebAssemblyHostEnvironment hostEnvironment,
            string clientName,
            string serverApiName,
            ClientMode clientMode)
            : base(hostEnvironment, clientName, serverApiName, clientMode)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFastThemeService, FastThemeService>();
        }
    }
}