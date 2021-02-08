namespace Bistrotic.WorkItems.Application.ModelViews
{
    public record PrioritySla(
        int Priority,
        int AcknowledgeTimeInMinutes,
        int ResolutionTimeInMinutes)
    {
    }
}