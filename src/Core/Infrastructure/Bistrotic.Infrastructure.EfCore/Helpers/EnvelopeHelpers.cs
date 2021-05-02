namespace Bistrotic.Infrastructure.EfCore.Helpers
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.EfCore.Repositories;

    using System;
    using System.Text.Json;

    public static class EnvelopeHelpers
    {
        public static OutboxMessage ToOutboxMessage(this IEnvelope envelope)
        {
            return new OutboxMessage()
            {
                MessageId = envelope.MessageId,
                CausationId = envelope.CausationId?.Value,
                CorrelationId = envelope.CorrelationId?.Value,
                UserName = envelope.UserName.Value,
                SystemUtcDateTime = DateTime.UtcNow,
                Event = JsonSerializer.Serialize(envelope.Message)
            };
        }
    }
}
