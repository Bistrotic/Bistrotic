using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

using Bistrotic.Application.Exceptions;

namespace Bistrotic.Application.Queries
{
    public class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private ImmutableDictionary<Type, Func<IQueryHandler>> _handlers;

        public InMemoryQueryDispatcher(Dictionary<Type, Func<IQueryHandler>> handlers)
        {
            _handlers = handlers?.ToImmutableDictionary() ?? throw new ArgumentNullException(nameof(handlers));
        }

        public Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            if (!_handlers.TryGetValue(query.GetType(), out Func<IQueryHandler>? handlerFunc))
            {
                return Task.FromException<TResult>(new QueryHandlerNotFoundException(query.GetType()));
            }
            IQueryHandler<TQuery, TResult>? handler = handlerFunc() as IQueryHandler<TQuery, TResult>;
            return handler?.Handle(query)
                ?? Task.FromException<TResult>(new InvalidQueryHandlerTypeException(handlerFunc().GetType(), typeof(IQueryHandler<TQuery, TResult>)));
        }
    }
}