using System;
using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : class, IQuery<TResult>
    {
        public bool CanHandle(Type queryType)
        {
            return queryType == typeof(TQuery);
        }

        public abstract Task<TResult> Handle(Envelope<TQuery> envelope);

        public async Task<object?> Handle(IEnvelope envelope)
        {
            return await Handle(new Envelope<TQuery>(envelope))
                .ConfigureAwait(false);
        }
    }
}