namespace Bistrotic.Application.Commands
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public abstract class Command
            : Message
    {
    }

    public abstract class Command<TId>
            : Message<TId> where TId : BusinessId, new()
    {
        protected Command()
        {
        }

        protected Command(TId id) : base(id)
        {
        }
    }
}