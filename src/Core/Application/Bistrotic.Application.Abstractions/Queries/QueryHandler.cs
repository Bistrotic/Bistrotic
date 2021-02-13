using System;
using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public bool CanHandle(Type queryType)
        {
            return queryType == typeof(TQuery);
        }

        public abstract Task<TResult> Handle(Envelope<TQuery> query);

        public async Task<object?> Handle(IEnvelope query)
        {
            return await Handle((Envelope<TQuery>)query)
                .ConfigureAwait(false);
        }
    }
}