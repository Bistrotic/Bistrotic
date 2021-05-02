using Bistrotic.Application.Repositories;
using Bistrotic.Infrastructure.EfCore.Repositories;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Bistrotic.Infrastructure.EfCore.Helpers
{
    public static class EventStoreHelpers
    {
        public static EventStreamItem ToEventStreamItem(this IEnumerable<object> events, string id, IRepositoryMetadata metadata, int version)
            => new()
            {
                CausationId = metadata.CausationId,
                CorrelationId = metadata.CorrelationId,
                Events = JsonSerializer.Serialize(events),
                Id = id,
                IdHash = id.HashKey(),
                UserName = metadata.UserName,
                SystemUtcDateTime = DateTime.UtcNow,
                Version = version
            };
    }
}
