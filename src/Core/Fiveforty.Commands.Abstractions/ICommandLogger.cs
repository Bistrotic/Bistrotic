using System.Threading.Tasks;

namespace Fiveforty.Commands
{
    public interface ICommandLogger
    {
        Task Log(ICommand command);
    }
}