namespace Bistrotic.WorkItems.Server
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal sealed class WorkItemsServerModule : ServerModule
    {
        public WorkItemsServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment)
            : base(moduleDefinition, configuration, environment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetWorkItemModuleSettings, WorkItemModuleSettings>, GetWorkItemModuleSettingsHandler>();
        }
    }
}