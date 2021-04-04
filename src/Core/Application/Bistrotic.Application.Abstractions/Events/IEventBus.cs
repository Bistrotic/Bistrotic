using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(Envelope<TEvent> envelope, CancellationToken cancellationToken = default)
            where TEvent : class;

        Task Publish(IEnvelope envelope, CancellationToken cancellationToken = default);
    }
}