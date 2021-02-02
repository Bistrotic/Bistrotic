using System.Threading.Tasks;

namespace Bistrotic.Application.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command);
    }
}