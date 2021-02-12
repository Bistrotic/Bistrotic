namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    public interface IQueryDispatcher
    {
        Task<object?> Dispatch(IEnvelope query);

        Task<TResult> Dispatch<TQuery, TResult>(Envelope<TQuery> query)
            where TQuery : IQuery<TResult>;
    }
}