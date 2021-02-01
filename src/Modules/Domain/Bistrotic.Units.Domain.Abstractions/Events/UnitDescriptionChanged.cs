namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Domain.ValueTypes;

    public record UnitDescriptionChanged(UserName UserName, UnitId UnitId, string? Description, MessageId CorrelationId, Etag? Etag = null) :
        UnitIdEvent(UserName, UnitId, CorrelationId, Etag)
    {
    }
}