namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Module.Units.ModelViews;
    using Bistrotic.Units.Application.Queries;
    using Bistrotic.Units.Domain.ValueTypes;

    public record GetUnitDetailedInformations(UnitId UnitId)
        : UnitIdQuery<UnitDetailedInformations>(UnitId)
    {
    }
}