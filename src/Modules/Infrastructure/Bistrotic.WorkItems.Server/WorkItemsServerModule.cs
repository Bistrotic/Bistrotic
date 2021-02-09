namespace Bistrotic.WorkItems.Server
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal sealed class WorkItemsServerModule : ServerModule
    {
        public WorkItemsServerModule(IConfiguration configuration)
            : base(new ModuleDefinition(nameof(WorkItems), typeof(WorkItemsServerModule).AssemblyQualifiedName ?? string.Empty), configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetWorkItemModuleSettings, WorkItemModuleSettings>, GetWorkItemModuleSettingsHandler>();
        }
    }
}