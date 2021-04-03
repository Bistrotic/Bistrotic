using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Commands
{
    public interface ICommandBus
    {
        Task Send<TCommand>(Envelope<TCommand> envelope)
            where TCommand : class;

        Task Send(IEnvelope envelope);
    }
}