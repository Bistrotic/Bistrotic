namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Module.Units.ModelViews;
    using Bistrotic.Queries;

    public record GetUnitSummaryInformations(string Id) : Query<UnitSummaryInformations>
    {
    }
}