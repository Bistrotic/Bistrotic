namespace Bistrotic.Units.Application.Commands
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class AddNewUnit
    {
        public AddNewUnit(UnitId unitId, string name, string? description)
        {
            UnitId = unitId;
            Name = name;
            Description = description;
        }

        public string? Description { get; }
        public string Name { get; }
        public string UnitId { get; }
    }
}