namespace Bistrotic.Application.Messages
{
    using Bistrotic.Domain.ValueTypes;

    public interface IEnvelope
    {
        MessageId? CausationId { get; }
        MessageId? CorrelationId { get; }
        object Message { get; }
        MessageId MessageId { get; }
        UserName UserName { get; }
    }
}