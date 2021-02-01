namespace Bistrotic.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;

    /// <summary>
    /// Interface ICommandDispatcher
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the t command.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}