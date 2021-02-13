namespace Bistrotic.Units.Application.Domain.Commands
{
    using Bistrotic.Units.Application.Commands;
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class ChangeUnitDescription : UnitIdCommand
    {
        public ChangeUnitDescription(UnitId unitId, string? description) : base(unitId)
        {
            Description = description;
        }

        public string? Description { get; }
    }
}