namespace Bistrotic.WorkItems.Application.Models
{
    public record PrioritySla(
        int Priority,
        int AcknowledgeTimeInMinutes,
        int ResolutionTimeInMinutes)
    {
    }
}