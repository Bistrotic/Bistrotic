using Bistrotic.Domain.Messages;
using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Application.Messages
{
    public class Envelope<T> : IEnvelope
        where T : IMessage
    {
        public Envelope(T message, UserName userName, MessageId? correlationId = null, MessageId? causationId = null)
        {
            UserName = userName;
            Message = message;
            CorrelationId = correlationId;
            CausationId = causationId;
        }

        public Envelope(T message, IEnvelope parent)
        {
            UserName = parent.UserName;
            Message = message;
            CorrelationId = parent.CorrelationId ?? parent.Message.MessageId;
            CausationId = parent.Message.MessageId;
        }

        public Envelope(IEnvelope envelope)
        {
            UserName = envelope.UserName;
            Message = (T)envelope.Message;
            CorrelationId = envelope.CorrelationId;
            CausationId = envelope.CausationId;
        }

        public MessageId? CorrelationId { get; }
        public MessageId? CausationId { get; }
        public T Message { get; }
        public UserName UserName { get; }
        IMessage IEnvelope.Message => Message;
    }
}