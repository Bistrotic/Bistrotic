namespace Bistrotic.MudBlazorTheme.Client
{
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.BlazorClient;
    using Bistrotic.MudBlazorTheme.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class MudBlazorThemeClientModule : ClientModule
    {
        public MudBlazorThemeClientModule(
            IWebAssemblyHostEnvironment hostEnvironment,
            string clientName,
            string serverApiName,
            ClientMode clientMode)
            : base(hostEnvironment, clientName, serverApiName, clientMode)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApplicationNameService, MudBlazorThemeService>();
        }
    }
}