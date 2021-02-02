namespace Bistrotic.Units.Application.Domain.Commands
{
    using Bistrotic.Units.Application.Commands;
    using Bistrotic.Units.Domain.ValueTypes;

    public record ChangeUnitDescription(UnitId UnitId, string? Description) :
        UnitIdCommand(UnitId)
    {
    }
}