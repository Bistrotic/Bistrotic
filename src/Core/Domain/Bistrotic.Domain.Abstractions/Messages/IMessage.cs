namespace Bistrotic.Domain.Messages
{
    public interface IMessage
    {
        string? Id { get; }
        string MessageId { get; }
    }
}