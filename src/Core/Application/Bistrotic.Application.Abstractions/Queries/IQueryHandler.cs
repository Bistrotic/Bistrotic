using System.Threading.Tasks;

namespace Bistrotic.Application.Queries
{
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}