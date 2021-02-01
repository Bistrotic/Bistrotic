namespace Bistrotic.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;

    /// <summary>
    /// Interface ICommandHandler
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        Task Execute(ICommand command);
    }

    /// <summary>
    /// Interface ICommandHandler
    /// </summary>
    /// <typeparam name="TCommand">The type of the t command.</typeparam>
    public interface ICommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        Task Execute(TCommand command);
    }
}