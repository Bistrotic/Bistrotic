﻿namespace Bistrotic.Commands
{
    /// <summary>
    /// Interface ICommand Implements the <see cref="System.Runtime.Serialization.ISerializable"/>
    /// </summary>
    /// <seealso cref="System.Runtime.Serialization.ISerializable"/>
    public interface ICommand
    {
        /// <summary>
        /// Gets the command identifier.
        /// </summary>
        /// <value>The command identifier.</value>
        /// <autogeneratedoc/>
        string CommandId { get; }
    }
}