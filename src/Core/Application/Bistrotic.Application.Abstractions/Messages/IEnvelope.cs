namespace Bistrotic.Application.Messages
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public interface IEnvelope
    {
        MessageId? CorrelationId { get; }
        Etag? Etag { get; }
        IMessage Message { get; }
        UserName UserName { get; }
    }
}