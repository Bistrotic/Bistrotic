namespace Bistrotic.Module.Units.Domain.Commands
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Application.Abstractions.ValueTypes;
    using Bistrotic.Units.Application.Commands;

    public record ChangeUnitDescription(UserName UserName, UnitId UnitId, Etag Etag, string? Description, MessageId? CorrelationId = null) :
        UnitIdCommand(UserName, UnitId, Etag, CorrelationId)
    {
    }
}