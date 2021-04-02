namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class GetUnitDetailedInformations
    {
        public GetUnitDetailedInformations(UnitId unitId)
        {
            UnitId = unitId;
        }

        public string UnitId { get; }
    }
}