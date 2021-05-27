
namespace Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers
{
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using global::MudBlazor.Services;

    using Microsoft.Extensions.DependencyInjection;

    public static class MudBlazorRendererHelper
    {
        public static void AddMudBlazorRenderers(this IServiceCollection services)
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
            services.AddTransient<IComponentRenderer, MenuAnchorRenderer>();
            services.AddTransient<IComponentRenderer, SpacerRenderer>();
            services.AddTransient<IComponentRenderer, ThemeRenderer>();
        }
    }
}
