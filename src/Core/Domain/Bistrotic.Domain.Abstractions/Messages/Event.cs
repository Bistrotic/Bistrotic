namespace Bistrotic.Domain.Messages
{
    using System;

    using Bistrotic.Domain.ValueTypes;

    public record Event(UserName UserName, BusinessId Id, MessageId CorrelationId, Etag? Etag = null)
        : Message(UserName, Id, CorrelationId), IEvent
    {
        public string EventId { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 22);
        public DateTime DateTime { get; } = DateTime.UtcNow;
    }
}