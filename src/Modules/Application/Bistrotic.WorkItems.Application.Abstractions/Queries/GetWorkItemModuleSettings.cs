namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;

    public record GetWorkItemModuleSettings : SettingsQuery<WorkItemModuleSettings>
    {
    }
}