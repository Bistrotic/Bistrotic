namespace Bistrotic.Application.Commands
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public abstract class Command : Message, ICommand
    {
    }

    public abstract class Command<TId> : Message<TId>, ICommand
        where TId : BusinessId, new()
    {
        protected Command()
        {
        }

        protected Command(TId id) : base(id)
        {
        }
    }
}