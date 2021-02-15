namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Application.ModelViews;
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class GetUnitDetailedInformations
        : UnitIdQuery<UnitDetailedInformations>
    {
        public GetUnitDetailedInformations(UnitId unitId) : base(unitId)
        {
        }
    }
}