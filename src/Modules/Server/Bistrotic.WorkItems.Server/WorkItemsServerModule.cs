namespace Bistrotic.WorkItems.Server
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class WorkItemsServerModule : ServerModule
    {
        public WorkItemsServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetWorkItemModuleSettings, WorkItemModuleSettings>, GetWorkItemModuleSettingsHandler>();
            services.AddTransient<IQueryHandler<GetIssuesWithSla, List<IssueWithSla>>, GetIssuesWithSlaHandler>();
            services.Configure<WorkItemModuleSettings>(Configuration.GetSection(nameof(WorkItemModuleSettings)));
        }
    }
}