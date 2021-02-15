namespace Bistrotic.Units.Application.Domain.Commands
{
    using Bistrotic.Units.Application.Commands;
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class RenameUnit :
        UnitIdCommand
    {
        public RenameUnit(UnitId unitId, string newName) : base(unitId)
        {
            NewName = newName;
        }

        public string NewName { get; }
    }
}