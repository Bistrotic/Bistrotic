namespace Bistrotic.Units.Application.Commands
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Application.Abstractions.ValueTypes;

    public record AddNewUnit(UserName UserName, UnitId UnitId, string Name, string? Description, MessageId? CorrelationId = null)
        : UnitIdCommand(UserName, UnitId, null, CorrelationId)
    {
    }
}