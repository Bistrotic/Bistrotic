﻿namespace Bistrotic.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;

    /// <summary>
    /// Interface ICommandLogger
    /// </summary>
    /// <autogeneratedoc/>
    public interface ICommandLogger
    {
        /// <summary>
        /// Logs the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        /// <autogeneratedoc/>
        Task Log(ICommand command);
    }
}