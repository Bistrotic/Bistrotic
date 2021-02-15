namespace Bistrotic.Application.Commands
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public bool CanHandle(Type CommandType)
        {
            return CommandType == typeof(TCommand);
        }

        public abstract Task Handle(Envelope<TCommand> envelope);

        public Task Handle(IEnvelope envelope)
           => Handle(new Envelope<TCommand>(envelope));
    }
}