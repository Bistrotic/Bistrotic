namespace Fiveforty.Module.Units.Queries
{
    using Fiveforty.Module.Units.ModelViews;
    using Fiveforty.Queries;

    public record GetUnitDetailedInformations(string Id) : Query<UnitDetailedInformations>
    {
    }
}