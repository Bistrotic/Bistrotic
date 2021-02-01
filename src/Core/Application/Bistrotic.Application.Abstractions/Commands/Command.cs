namespace Bistrotic.Application.Commands
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public record Command(BusinessId? Id = null)
            : Message(Id)
    {
    }
}