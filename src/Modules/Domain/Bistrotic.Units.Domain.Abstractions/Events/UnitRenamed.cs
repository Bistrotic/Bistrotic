namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public record UnitRenamed(UnitId UnitId, string NewName) :
        UnitIdEvent(UnitId)
    {
    }
}