namespace Bistrotic.Module.Units.Domain.Commands
{
    using Bistrotic.Units.Application.Commands;
    using Bistrotic.Units.Domain.ValueTypes;

    public record RenameUnit(UnitId UnitId, string NewName) :
        UnitIdCommand(UnitId)
    {
    }
}