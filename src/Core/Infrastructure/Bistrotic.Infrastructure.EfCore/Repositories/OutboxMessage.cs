using System;

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    [Serializable]
    public class OutboxMessage
    {
        public string MessageId { get; set; } = string.Empty;
        public string? CausationId { get; set; } = string.Empty;
        public string? CorrelationId { get; set; } = string.Empty;
        public string Event { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime? SentUtcDateTime { get; set; }
        public DateTime SystemUtcDateTime { get; set; }
        public DateTimeOffset UserDateTime { get; }
        public string UserName { get; set; } = string.Empty;
    }
}