
namespace Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers
{

    using Bistrotic.Infrastructure.VisualComponents.Controls;
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.Extensions.DependencyInjection;

    public static class MudBlazorRendererHelper
    {
        public static void AddMudBlazorRenderers(this IServiceCollection services)
        {
            services.AddTransient<IComponentRenderer<Alert>, AlertRenderer>();
            services.AddTransient<IComponentRenderer<Anchor>, AnchorRenderer>();
            services.AddTransient<IComponentRenderer<Badge>, BadgeRenderer>();
            services.AddTransient<IComponentRenderer<Button>, ButtonRenderer>();
            services.AddTransient<IComponentRenderer<Icon>, IconRenderer>();
            services.AddTransient<IComponentRenderer<MenuAnchor>, MenuAnchorRenderer>();
            services.AddTransient<IComponentRenderer<MenuItem>, MenuItemRenderer>();
            services.AddTransient<IComponentRenderer<Menu>, MenuRenderer>();
            services.AddTransient<IComponentRenderer<MenuAnchor>, MenuAnchorRenderer>();
            services.AddTransient<IComponentRenderer<Spacer>, SpacerRenderer>();
            services.AddTransient<IComponentRenderer<Theme>, ThemeRenderer>();
        }
    }
}
