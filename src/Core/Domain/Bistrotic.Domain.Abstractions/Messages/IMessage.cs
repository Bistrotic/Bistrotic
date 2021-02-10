using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public interface IMessage
    {
        string Domain { get; }
        BusinessId? Id { get; }
        MessageId MessageId { get; }
    }
}