namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Domain.ValueTypes;

    public record UnitRenamed(UserName UserName, UnitId UnitId, MessageId CorrelationId, Etag? Etag, string NewName) :
        UnitIdEvent(UserName, UnitId, CorrelationId, Etag)
    {
    }
}