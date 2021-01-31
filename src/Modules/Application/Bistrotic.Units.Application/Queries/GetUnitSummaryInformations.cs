namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Application.ModelViews;
    using Bistrotic.Queries;

    public record GetUnitSummaryInformations(string Id) : Query<UnitSummaryInformations>
    {
    }
}