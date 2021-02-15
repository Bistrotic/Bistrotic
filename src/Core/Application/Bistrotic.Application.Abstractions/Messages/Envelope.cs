using Bistrotic.Domain.Messages;
using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Application.Messages
{
    public class Envelope<T> : IEnvelope
        where T : IMessage
    {
        public Envelope(T message, UserName userName, MessageId? correlationId = null, Etag? etag = null)
        {
            UserName = userName;
            Message = message;
            CorrelationId = correlationId;
            Etag = etag;
        }

        public Envelope(IEnvelope envelope)
        {
            UserName = envelope.UserName;
            Message = (T)envelope.Message;
            CorrelationId = envelope.CorrelationId;
            Etag = envelope.Etag;
        }

        public MessageId? CorrelationId { get; }
        public Etag? Etag { get; }
        public T Message { get; }
        public UserName UserName { get; }
        IMessage IEnvelope.Message => Message;
    }
}