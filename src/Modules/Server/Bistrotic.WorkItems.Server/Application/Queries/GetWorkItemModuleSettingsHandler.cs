namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;

    using Microsoft.Extensions.Options;

    public sealed class GetWorkItemModuleSettingsHandler : SettingsQueryHandler<GetWorkItemModuleSettings, WorkItemModuleSettings>
    {
        public GetWorkItemModuleSettingsHandler(IOptions<WorkItemModuleSettings> options) : base(options)
        {
        }
    }
}