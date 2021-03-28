using System;

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    [Serializable]
    public class EventStreamItem
    {
        public string CausationId { get; } = string.Empty;
        public string CorrelationId { get; } = string.Empty;
        public string Events { get; set; } = string.Empty;
        public int Hash { get; set; }
        public string PartitionId { get; set; } = string.Empty;
        public string StreamId { get; set; } = string.Empty;
        public DateTime SystemUtcDateTime { get; }
        public DateTimeOffset UserDateTime { get; }
        public string UserName { get; } = string.Empty;
        public int Version { get; set; }
    }
}