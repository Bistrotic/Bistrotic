using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Events
{
    public interface IEventBus
    {
        Task Send<TEvent>(Envelope<TEvent> envelope)
            where TEvent : class;

        Task Send(IEnvelope envelope);
    }
}