namespace Bistrotic.Application.Commands
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public record Command(string Domain, BusinessId? Id = null)
            : Message(Domain, Id)
    {
    }
}