namespace Bistrotic.WorkItems.Application.Abstractions.ModelViews
{
    using System.Collections.Immutable;

    public record ProjectSla(
        string ProjectName,
        ImmutableArray<PrioritySla> PrioritySlas)
    {
    }
}