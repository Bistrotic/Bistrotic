namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query);
    }
}