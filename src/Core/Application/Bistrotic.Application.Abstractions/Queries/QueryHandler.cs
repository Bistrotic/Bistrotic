using System;
using System.Threading.Tasks;

namespace Bistrotic.Application.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public bool CanHandle(Type queryType)
        {
            return queryType == typeof(TQuery);
        }

        public abstract Task<TResult> Handle(TQuery query);

        public async Task<object?> Handle(IQuery query)
        {
            return await Handle((TQuery)query).ConfigureAwait(false);
        }
    }
}