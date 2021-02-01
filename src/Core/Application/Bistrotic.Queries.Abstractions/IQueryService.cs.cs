namespace Bistrotic.Queries
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;

    public interface IQueryService
    {
        Task<TResult> Ask<TResult>(IQuery<TResult> query);
    }
}