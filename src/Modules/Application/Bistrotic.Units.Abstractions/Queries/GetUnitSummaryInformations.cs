namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Module.Units.ModelViews;
    using Bistrotic.Units.Application.Abstractions.ValueTypes;
    using Bistrotic.Units.Application.Queries;

    public record GetUnitSummaryInformations(UserName UserName, UnitId UnitId) : UnitIdQuery<UnitSummaryInformations>(UserName, UnitId)
    {
    }
}