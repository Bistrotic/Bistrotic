namespace Bistrotic.Infrastructure.EfCore.Helpers
{
    using System;
    using System.Text.Json;

    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.EfCore.Repositories;

    public static class EnvelopeHelpers
    {
        public static OutboxMessage ToOutboxMessage(this IEnvelope envelope, Type repository)
        {
            return new OutboxMessage()
            {
                RepositoryType = repository.AssemblyQualifiedName ?? throw new TypeInitializationException(repository.FullName, null),
                MessageId = envelope.MessageId,
                CausationId = envelope.CausationId?.Value,
                CorrelationId = envelope.CorrelationId?.Value,
                UserName = envelope.UserName.Value,
                SystemUtcDateTime = DateTime.UtcNow,
                EventType = envelope.Message.GetType().AssemblyQualifiedName ?? throw new TypeAccessException($"The type {envelope.Message.GetType().Name} assembly qualified name is null. Can't persist the envelope (MessageId={envelope.MessageId}) in the outbox store."),
                Event = JsonSerializer.Serialize(envelope.Message)
            };
        }
    }
}