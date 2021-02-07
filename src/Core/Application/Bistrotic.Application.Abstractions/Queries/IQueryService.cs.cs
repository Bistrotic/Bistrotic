namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    public interface IQueryService
    {
        Task<TResult> Ask<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
    }
}