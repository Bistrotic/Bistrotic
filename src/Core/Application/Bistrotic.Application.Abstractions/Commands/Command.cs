namespace Bistrotic.Application.Commands
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public record Command(
        UserName UserName,
        BusinessId? Id = null,
        Etag? Etag = null,
        MessageId? CorrelationId = null)
            : Message(UserName, Id, CorrelationId)
    {
    }
}