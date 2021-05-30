namespace Bistrotic.Application.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    public interface IQueryBus
    {
        Task<object?> Dispatch(IEnvelope envelope, CancellationToken cancellationToken = default);

        Task<TResult> Dispatch<TQuery, TResult>(Envelope<TQuery> envelope, CancellationToken cancellationToken = default)
            where TQuery : class;
    }
}