namespace Bistrotic.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;

    public interface ICommandService
    {
        Task Tell(ICommand command);
    }
}