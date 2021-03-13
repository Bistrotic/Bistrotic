using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Application.Messages
{
    public class Envelope<T> : IEnvelope
        where T : class
    {
        public Envelope(T message, MessageId messageId, UserName userName, MessageId? correlationId = null, MessageId? causationId = null)
        {
            UserName = userName;
            Message = message;
            CorrelationId = correlationId;
            CausationId = causationId;
            MessageId = messageId;
        }

        public Envelope(T message, MessageId messageId, IEnvelope parent)
        {
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
        }

        public MessageId? CausationId { get; }
        public MessageId? CorrelationId { get; }
        public T Message { get; }
        public MessageId MessageId { get; }
        public UserName UserName { get; }
        object IEnvelope.Message => Message;
    }
}