using System;

using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Application.Messages
{
    public class Envelope<T> : IEnvelope
        where T : class
    {
        public Envelope(T message, MessageId messageId, UserName userName, DateTimeOffset userDateTime, MessageId? correlationId = null, MessageId? causationId = null)
        {
            UserName = userName;
            Message = message;
            CorrelationId = correlationId;
            CausationId = causationId;
            MessageId = messageId;
            UserDateTime = userDateTime;
        }

        public Envelope(T message, MessageId messageId, IEnvelope parent)
        {
            UserDateTime = parent.UserDateTime;
            UserName = parent.UserName;
            Message = message;
            CorrelationId = parent.CorrelationId ?? parent.MessageId;
            CausationId = parent.MessageId;
            MessageId = messageId;
        }

        public Envelope(IEnvelope envelope)
        {
            UserName = envelope.UserName;
            Message = (T)envelope.Message;
            CorrelationId = envelope.CorrelationId;
            CausationId = envelope.CausationId;
            MessageId = envelope.MessageId;
            UserDateTime = envelope.UserDateTime;
        }

        public MessageId? CausationId { get; init; }
        public MessageId? CorrelationId { get; init; }
        public T Message { get; init; }
        public MessageId MessageId { get; init; }
        public DateTimeOffset UserDateTime { get; init; }
        public UserName UserName { get; init; }
        object IEnvelope.Message => Message;
    }
}