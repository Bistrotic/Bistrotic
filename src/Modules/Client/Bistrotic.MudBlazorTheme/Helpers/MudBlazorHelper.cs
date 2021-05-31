namespace Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers
{
    using global::MudBlazor.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class MudBlazorHelper
    {
        public static void AddMudBlazorTheme(this IServiceCollection services)
        {
            services.AddMudServices();
        }

        public static void AddMudBlazorThemeClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudBlazorTheme();
        }
    }
}