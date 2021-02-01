namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public record NewUnitAdded(UnitId UnitId, string Name, string? Description) :
        UnitIdEvent(UnitId)
    {
    }
}