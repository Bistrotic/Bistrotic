using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public interface IMessage
    {
        BusinessId? Id { get; }
        MessageId MessageId { get; }
    }
}