namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    public interface IQueryService
    {
        Task<TResult> Ask<TQuery, TResult>(string messageId, TQuery query)
            where TQuery : class, IQuery<TResult>;
    }
}