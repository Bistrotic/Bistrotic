namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class GetUnitSummaryInformations
    {
        public GetUnitSummaryInformations(UnitId unitId)
        {
            UnitId = unitId;
        }

        public string UnitId { get; }
    }
}