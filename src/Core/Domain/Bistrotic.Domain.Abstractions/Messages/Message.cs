using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public record Message(BusinessId? Id = null, MessageId? CorrelationId = null) : IMessage
    {
        public MessageId MessageId { get; } = new MessageId();
    }
}