namespace Bistrotic.Application.Commands
{
    using System.Threading.Tasks;

    public interface ICommandService
    {
        Task Tell<TCommand>(TCommand command) where TCommand : ICommand;
    }
}