namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    public interface IQueryDispatcher
    {
        Task<object?> Dispatch(IQuery query);

        Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>;
    }
}