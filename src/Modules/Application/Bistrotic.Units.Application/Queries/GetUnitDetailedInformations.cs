namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Application.ModelViews;
    using Bistrotic.Queries;

    public record GetUnitDetailedInformations(string Id) : Query<UnitDetailedInformations>
    {
    }
}