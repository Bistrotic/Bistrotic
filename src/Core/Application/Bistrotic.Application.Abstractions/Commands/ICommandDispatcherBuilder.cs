namespace Bistrotic.Application.Commands
{
    using System;

    public interface ICommandDispatcherBuilder
    {
        ICommandDispatcherBuilder AddCommandHandler<TCommand>(Func<ICommandHandler<TCommand>> handler)
            where TCommand : class;

        ICommandDispatcher Build();
    }
}