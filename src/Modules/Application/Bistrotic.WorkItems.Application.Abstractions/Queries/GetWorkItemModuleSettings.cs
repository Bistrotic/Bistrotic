namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Domain;

    public record GetWorkItemModuleSettings()
        : SettingsQuery<WorkItemModuleSettings>(WorkItemConstants.DomainName)
    {
    }
}