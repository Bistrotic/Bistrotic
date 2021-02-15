namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class UnitDescriptionChanged :
        UnitIdEvent
    {
        public UnitDescriptionChanged(UnitId unitId, string? description) : base(unitId)
        {
            Description = description;
        }

        public string? Description { get; }
    }
}