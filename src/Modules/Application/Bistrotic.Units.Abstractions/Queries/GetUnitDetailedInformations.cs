namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Module.Units.ModelViews;
    using Bistrotic.Units.Application.Abstractions.ValueTypes;
    using Bistrotic.Units.Application.Queries;

    public record GetUnitDetailedInformations(UserName UserName, UnitId UnitId)
        : UnitIdQuery<UnitDetailedInformations>(UserName, UnitId)
    {
    }
}