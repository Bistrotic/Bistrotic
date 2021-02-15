namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    public interface IQueryDispatcher
    {
        Task<object?> Dispatch(IEnvelope envelope);

        Task<TResult> Dispatch<TQuery, TResult>(Envelope<TQuery> envelope)
            where TQuery : IQuery<TResult>;
    }
}