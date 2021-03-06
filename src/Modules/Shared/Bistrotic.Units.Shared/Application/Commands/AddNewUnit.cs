namespace Bistrotic.Units.Application.Commands
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class AddNewUnit : UnitIdCommand
    {
        public AddNewUnit(UnitId unitId, string name, string? description) : base(unitId)
        {
            Name = name;
            Description = description;
        }

        public string? Description { get; }
        public string Name { get; }
    }
}
