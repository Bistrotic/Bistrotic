namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Application.ModelViews;
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class GetUnitSummaryInformations : UnitIdQuery<UnitSummaryInformations>
    {
        public GetUnitSummaryInformations(UnitId unitId) : base(unitId)
        {
        }
    }
}