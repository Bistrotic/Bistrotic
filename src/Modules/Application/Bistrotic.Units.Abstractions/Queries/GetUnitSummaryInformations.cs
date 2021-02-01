namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Module.Units.ModelViews;
    using Bistrotic.Units.Application.Queries;
    using Bistrotic.Units.Domain.ValueTypes;

    public record GetUnitSummaryInformations(UnitId UnitId) : UnitIdQuery<UnitSummaryInformations>(UnitId)
    {
    }
}