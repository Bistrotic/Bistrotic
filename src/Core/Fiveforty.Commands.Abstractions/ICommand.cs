namespace Fiveforty.Commands
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Interface ICommand Implements the <see cref="System.Runtime.Serialization.ISerializable"/>
    /// </summary>
    /// <seealso cref="System.Runtime.Serialization.ISerializable"/>
    public interface ICommand : ISerializable
    {
        /// <summary>
        /// Gets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        Guid MessageId { get; }
    }
}