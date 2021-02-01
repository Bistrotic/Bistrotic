using Bistrotic.Domain.Messages;

namespace Bistrotic.Application.Commands
{
    /// <summary>
    /// Interface ICommand Implements the <see cref="System.Runtime.Serialization.ISerializable"/>
    /// </summary>
    /// <seealso cref="System.Runtime.Serialization.ISerializable"/>
    public interface ICommand : IMessage
    {
    }
}