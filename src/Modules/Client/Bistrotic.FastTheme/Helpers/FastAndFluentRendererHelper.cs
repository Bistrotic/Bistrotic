namespace Bistrotic.FastTheme.Helpers
{
    using Bistrotic.FastTheme.Renderers.Fast;
    using Bistrotic.FastTheme.Renderers.Fluent;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class FastAndFluentRendererHelper
    {
        public static void AddFastRenderers(this IServiceCollection services)
        {
            services.AddTransient<IComponentRenderer, FastThemeRenderer>();
            services.AddTransient<IComponentRenderer, FastListboxRenderer>();
            services.AddTransient<IComponentRenderer, FastOptionRenderer>();
        }

        public static void AddFastTheme(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddFastTheme();
        }

        public static void AddFastTheme(this IServiceCollection services)
        {
            services.AddFastRenderers();
            services.AddFluentRenderers();
        }

        public static void AddFluentRenderers(this IServiceCollection services)
        {
            services.AddTransient<IComponentRenderer, FluentThemeRenderer>();
            services.AddTransient<IComponentRenderer, FluentListboxRenderer>();
            services.AddTransient<IComponentRenderer, FluentOptionRenderer>();
        }
    }
}