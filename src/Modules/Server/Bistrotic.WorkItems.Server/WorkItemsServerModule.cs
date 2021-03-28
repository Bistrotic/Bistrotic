namespace Bistrotic.WorkItems
{
    using System.Collections.Generic;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;
    using Bistrotic.WorkItems.Application.QueryHandlers;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class WorkItemsServerModule : ServerModule
    {
        public WorkItemsServerModule(
            IConfiguration configuration,
            IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetIssuesWithSla).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetWorkItemChangeHistory, IEnumerable<WorkItemChange>>, GetWorkItemChangeHistoryHandler>();
            services.AddTransient<IQueryHandler<GetWorkItemModuleSettings, WorkItemModuleSettings>, GetWorkItemModuleSettingsHandler>();
            services.AddTransient<IQueryHandler<GetIssuesWithSla, List<IssueWithSla>>, GetIssuesWithSlaHandler>();
            services.AddTransient<IQueryHandler<GetSecurityGroupMembers, IEnumerable<SecurityGroupMember>>, GetSecurityGroupMembersHandler>();
            services.Configure<WorkItemModuleSettings>(Configuration.GetSection(nameof(WorkItemModuleSettings)));
        }
    }
}