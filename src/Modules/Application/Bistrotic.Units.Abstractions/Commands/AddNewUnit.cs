namespace Bistrotic.Units.Application.Commands
{
    using Bistrotic.Units.Domain.ValueTypes;

    public record AddNewUnit(UnitId UnitId, string Name, string? Description)
        : UnitIdCommand(UnitId)
    {
    }
}