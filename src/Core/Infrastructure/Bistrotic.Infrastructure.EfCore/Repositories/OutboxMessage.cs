using System;

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    [Serializable]
    public class OutboxMessage
    {
        public string? CausationId { get; set; }
        public string? CorrelationId { get; set; }
        public string Event { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime? InProgressSince { get; set; }
        public string MessageId { get; set; } = string.Empty;
        public string RepositoryType { get; set; } = string.Empty;
        public DateTime? SentUtcDateTime { get; set; }
        public DateTime SystemUtcDateTime { get; set; }
        public DateTimeOffset UserDateTime { get; }
        public string UserName { get; set; } = string.Empty;
    }
}