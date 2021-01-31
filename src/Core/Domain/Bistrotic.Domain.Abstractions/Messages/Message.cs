using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public record Message(MessageId MessageId, UserName UserName, BusinessId? Id = null, MessageId? CorrelationId = null) : IMessage
    {
    }
}