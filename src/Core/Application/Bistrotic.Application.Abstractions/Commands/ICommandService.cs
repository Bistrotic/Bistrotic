namespace Bistrotic.Application.Commands
{
    using System.Threading.Tasks;

    public interface ICommandService
    {
        Task Tell<TCommand>(string messageId, TCommand command);
    }
}