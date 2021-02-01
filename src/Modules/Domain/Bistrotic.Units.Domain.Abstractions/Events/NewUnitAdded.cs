namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Domain.ValueTypes;

    public record NewUnitAdded(UserName UserName, UnitId UnitId, string Name, string? Description, MessageId CorrelationId, Etag? Etag = null) :
        UnitIdEvent(UserName, UnitId, CorrelationId, Etag)
    {
    }
}