namespace Bistrotic.WorkItems.Application.Queries
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;

    using Microsoft.Extensions.Configuration;

    public class GetWorkItemModuleSettingsHandler : QueryHandler<GetWorkItemModuleSettings, WorkItemModuleSettings>
    {
        private readonly IConfiguration _configuration;

        public GetWorkItemModuleSettingsHandler(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public override Task<WorkItemModuleSettings> Handle(GetWorkItemModuleSettings query)
        {
            var settings = JsonSerializer
                .Deserialize<WorkItemModuleSettings>(_configuration.GetSection(nameof(WorkItemModuleSettings)).Value);
            return Task.FromResult(settings ?? new WorkItemModuleSettings());
        }
    }
}