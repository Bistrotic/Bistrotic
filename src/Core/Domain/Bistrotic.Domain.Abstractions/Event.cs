namespace Fiveforty.Domain.Messages
{
    using System;

    public record Event(string UserName, string? Id = null, string? Etag = null) : IEvent
    {
        public string EventId { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 22);
        public DateTime DateTime { get; } = DateTime.UtcNow;
    }
}