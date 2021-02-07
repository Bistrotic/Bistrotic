namespace Bistrotic.WorkItems.Application.Abstractions.ModelViews
{
    public record PrioritySla(
        int Priority,
        int AcknowledgeTimeInMinutes,
        int ResolutionTimeInMinutes)
    {
    }
}