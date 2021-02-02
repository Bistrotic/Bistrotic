namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Application.ModelViews;
    using Bistrotic.Units.Domain.ValueTypes;

    public record GetUnitDetailedInformations(UnitId UnitId)
        : UnitIdQuery<UnitDetailedInformations>(UnitId)
    {
    }
}