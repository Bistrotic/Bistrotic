namespace Fiveforty.Domain
{
    using System;
    using System.Runtime.Serialization;

    using Fiveforty.Domain.Messages;

    [Serializable]
    internal class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {
        }

        public InvalidCommandException(IAggregateRoot aggregate, ICommand command, string? message, Exception? innerException) :
            base($"The command '{command?.GetType()?.Name ?? "??"}' is invalid for aggregate '{aggregate?.AggregateName ?? "??"}'. {message}", innerException)
        {
        }

        public InvalidCommandException(string? message) : base(message)
        {
        }

        public InvalidCommandException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}