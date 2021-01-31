namespace Bistrotic.Commands
{
    using System.Threading.Tasks;

    public interface ICommandService
    {
        Task Tell(ICommand command);
    }
}