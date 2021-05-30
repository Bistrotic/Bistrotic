namespace Bistrotic.Infrastructure.WebServer.Helpers
{
    using System.Security.Principal;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Identities;
    using Bistrotic.Application.Queries;
    using Bistrotic.Application.Services;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;
    using Bistrotic.Infrastructure.WebServer.Exceptions;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebServerHelper
    {
        public static void AddWebServer(this IServiceCollection services)
        {
            services.AddTransient<IComponentRendererProvider, ComponentRendererProvider>();
            services.AddScoped<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()?.HttpContext?.User ?? throw new HttpContextNotFoundException());
            services.AddScoped<IUserIdentity, UserIdentity>();
            services.AddScoped<IQueryService, QueryService>();
            services.AddScoped<ICommandService, CommandService>();
        }
    }
}