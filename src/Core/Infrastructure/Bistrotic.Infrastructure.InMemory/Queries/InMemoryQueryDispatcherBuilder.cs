namespace Bistrotic.Infrastructure.InMemory.Queries
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;

    public class InMemoryQueryDispatcherBuilder : IQueryDispatcherBuilder
    {
        private readonly Dictionary<Type, Func<IQueryHandler>> _handlers = new Dictionary<Type, Func<IQueryHandler>>();

        public IQueryDispatcherBuilder AddQueryHandler<TQuery, TResult>(Func<IQueryHandler<TQuery, TResult>> handler)
            where TQuery : class, IQuery<TResult>
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