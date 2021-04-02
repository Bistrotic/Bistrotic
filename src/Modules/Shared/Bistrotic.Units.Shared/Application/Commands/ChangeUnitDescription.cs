namespace Bistrotic.Units.Application.Domain.Commands
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class ChangeUnitDescription
    {
        public ChangeUnitDescription(UnitId unitId, string? description)
        {
            Description = description;
            UnitId = unitId;
        }

        public string? Description { get; }
        public string UnitId { get; }
    }
}