namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class UnitDescriptionChanged
    {
        public UnitDescriptionChanged(UnitId unitId, string? description)
        {
            Description = description;
            UnitId = unitId;
        }

        public string? Description { get; }
        public string UnitId { get; }
    }
}