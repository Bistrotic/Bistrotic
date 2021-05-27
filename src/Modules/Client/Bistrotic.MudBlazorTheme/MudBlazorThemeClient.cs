namespace Bistrotic.MudBlazorTheme.Client
{
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers;
    using Bistrotic.MudBlazorTheme.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class MudBlazorThemeClient
    {
        public static void AddMudBlazorThemeClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudBlazorRenderers();
            builder.Services.AddTransient<IMudBlazorThemeService, MudBlazorThemeService>();
        }
    }
}