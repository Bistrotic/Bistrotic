namespace Bistrotic.Infrastructure.WebServer.Helpers
{
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.Extensions.DependencyInjection;

    public static class WebServerHelper
    {
        public static void AddWebServer(this IServiceCollection services)
        {
            services.AddTransient<IComponentRendererProvider, ComponentRendererProvider>();
        }
    }
}
