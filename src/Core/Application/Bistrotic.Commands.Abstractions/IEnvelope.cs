using System;

namespace Bistrotic.Commands
{
    public interface IEnvelope<TMessage>
    {
        TCommand Command { get; }
        string MessageId { get; }
        string MessageId { get; }
        string MessageId { get; }
        DateTimeOffset UserDateTime { get; }
        string UserName { get; }
    }
}