namespace Bistrotic.WorkItems.Application.Abstractions.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.Abstractions.ModelViews;

    public record GetWorkItemModuleSettings : Query<WorkItemModuleSettings>
    {
    }
}