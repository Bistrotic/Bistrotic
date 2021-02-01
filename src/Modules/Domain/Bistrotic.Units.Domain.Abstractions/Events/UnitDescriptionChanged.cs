namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public record UnitDescriptionChanged(UnitId UnitId, string? Description) :
        UnitIdEvent(UnitId)
    {
    }
}