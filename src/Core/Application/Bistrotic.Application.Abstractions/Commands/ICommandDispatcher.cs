using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch(IEnvelope envelope);

        Task Dispatch<TCommand>(Envelope<TCommand> envelope)
            where TCommand : class;
    }
}