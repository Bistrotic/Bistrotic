namespace Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers
{
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using global::MudBlazor.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class MudBlazorHelper
    {
        public static void AddMudBlazorTheme(this IServiceCollection services)
        {
            services.AddMudServices();
            services.AddTransient<IComponentRenderer, AlertRenderer>();
            services.AddTransient<IComponentRenderer, AnchorRenderer>();
            services.AddTransient<IComponentRenderer, BadgeRenderer>();
            services.AddTransient<IComponentRenderer, ButtonRenderer>();
            services.AddTransient<IComponentRenderer, IconRenderer>();
            services.AddTransient<IComponentRenderer, MenuAnchorRenderer>();
            services.AddTransient<IComponentRenderer, MenuItemRenderer>();
            services.AddTransient<IComponentRenderer, MenuRenderer>();
            services.AddTransient<IComponentRenderer, SpacerRenderer>();
            services.AddTransient<IComponentRenderer, ThemeRenderer>();
            services.AddTransient<IComponentRenderer, ListboxRenderer>();
            services.AddTransient<IComponentRenderer, OptionRenderer>();
        }

        public static void AddMudBlazorThemeClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudBlazorTheme();
        }
    }
}