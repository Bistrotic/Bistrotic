using System.Threading.Tasks;

namespace Bistrotic.Application.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public abstract Task<TResult> Handle(TQuery query);
    }
}