﻿using System;

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    [Serializable]
    public class EventStreamItem
    {
        public string? CausationId { get; set; } = string.Empty;
        public string? CorrelationId { get; set; } = string.Empty;
        public string Events { get; set; } = string.Empty;
        public int IdHash { get; set; }
        public string Id { get; set; } = string.Empty;
        public DateTime SystemUtcDateTime { get; set; }
        public DateTimeOffset UserDateTime { get; }
        public string UserName { get; set; } = string.Empty;
        public int Version { get; set; }
    }
}