namespace Bistrotic.FastTheme.Client
{
    using Bistrotic.FastTheme.Services;
    using Bistrotic.Infrastructure.VisualComponents.FastAndFluent.Helpers;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class FastThemeClient
    {
        public static void AddFastThemeClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddTransient<IFastThemeService, FastThemeService>();
            builder.Services.AddFastRenderers();
            builder.Services.AddFluentRenderers();
        }
    }
}