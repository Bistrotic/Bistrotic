namespace Bistrotic.Application.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    /// <summary>
    /// Interface ICommandHandler
    /// </summary>
    public interface ICommandHandler
    {
        Task Handle(IEnvelope envelope);
    }

    /// <summary>
    /// Interface ICommandHandler
    /// </summary>
    /// <typeparam name="TCommand">The type of the t command.</typeparam>
    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        Task Handle(Envelope<TCommand> envelope);
    }
}