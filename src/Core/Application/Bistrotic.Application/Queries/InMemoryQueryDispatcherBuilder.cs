namespace Bistrotic.Application.Queries
{
    using System;
    using System.Collections.Generic;

    public class InMemoryQueryDispatcherBuilder : IQueryDispatcherBuilder
    {
        private readonly Dictionary<Type, Func<IQueryHandler>> _handlers = new Dictionary<Type, Func<IQueryHandler>>();

        public IQueryDispatcherBuilder AddQueryHandler<TQuery, TResult>(Func<IQueryHandler<TQuery, TResult>> handler)
            where TQuery : IQuery<TResult>
        {
            _handlers.Add(typeof(TQuery), handler);
            return this;
        }

        public IQueryDispatcher Build()
        {
            return new InMemoryQueryDispatcher(_handlers);
        }
    }
}