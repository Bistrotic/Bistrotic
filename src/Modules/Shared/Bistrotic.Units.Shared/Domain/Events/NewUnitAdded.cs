namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class NewUnitAdded
        : UnitIdEvent
    {
        public NewUnitAdded(UnitId unitId, string name, string? description) : base(unitId)
        {
            Name = name;
            Description = description;
        }

        public string? Description { get; }
        public string Name { get; }
    }
}