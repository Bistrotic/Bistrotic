using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public interface IMessage
    {
        MessageId? CorrelationId { get; }
        BusinessId? Id { get; }
        MessageId MessageId { get; }
        UserName UserName { get; }
    }
}