namespace Bistrotic.Application.Commands
{
    using System;
    using System.Collections.Generic;

    public class InMemoryCommandDispatcherBuilder : ICommandDispatcherBuilder
    {
        private readonly Dictionary<Type, Func<ICommandHandler>> _handlers = new Dictionary<Type, Func<ICommandHandler>>();

        public ICommandDispatcherBuilder AddCommandHandler<TCommand>(Func<ICommandHandler<TCommand>> handler)
            where TCommand : class
        {
            _handlers.Add(typeof(TCommand), handler);
            return this;
        }

        public ICommandDispatcher Build()
        {
            return new InMemoryCommandDispatcher(_handlers);
        }
    }
}