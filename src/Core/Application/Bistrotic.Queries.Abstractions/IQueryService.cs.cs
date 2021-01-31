namespace Bistrotic.Queries
{
    using System.Threading.Tasks;

    public interface IQueryService
    {
        Task<TResult> Ask<TResult>(IQuery<TResult> query);
    }
}