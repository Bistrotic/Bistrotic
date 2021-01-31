using System;

namespace Bistrotic.Commands
{
    public record Envelope<TCommand>(TCommand Command, string UserName, DateTimeOffset UserDateTime)
        : IEnvelope<TCommand> where TCommand : ICommand
    {
    }
}