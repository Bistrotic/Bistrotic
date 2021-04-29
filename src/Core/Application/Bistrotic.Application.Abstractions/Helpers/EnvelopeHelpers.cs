using Bistrotic.Application.Messages;
using Bistrotic.Application.Repositories;

using System;

namespace Bistrotic.Application.Helpers
{
    public static class EnvelopeHelpers
    {
        public static IRepositoryMetadata ToMetadata(this IEnvelope envelope)
            => new RepositoryMetadata
            {
                MessageId = envelope.MessageId,
                CausationId = envelope.CausationId?.Value,
                CorrelationId = envelope.CorrelationId?.Value,
                SystemUtcDateTime = DateTime.UtcNow,
                UserDateTime = envelope.UserDateTime,
                UserName = envelope.UserName
            };
    }
}
