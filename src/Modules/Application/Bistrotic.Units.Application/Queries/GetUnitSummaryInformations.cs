namespace Fiveforty.Module.Units.Queries
{
    using Fiveforty.Module.Units.ModelViews;
    using Fiveforty.Queries;

    public record GetUnitSummaryInformations(string Id) : Query<UnitSummaryInformations>
    {
    }
}