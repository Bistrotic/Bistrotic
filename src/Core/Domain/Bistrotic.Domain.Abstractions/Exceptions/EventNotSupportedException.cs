using System;
using System.Runtime.Serialization;

namespace Bistrotic.Domain.Exceptions
{
    [Serializable]
    public class EventNotSupportedException<TState> : Exception
    {
        public EventNotSupportedException()
        {
        }

        public EventNotSupportedException(string? message) : base(message)
        {
        }

        public EventNotSupportedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public EventNotSupportedException(object @event, string? message, Exception? innerException)
            : base($"Event '{@event?.GetType().Name}' is not supported by state '{typeof(TState).Name}'.{message}", innerException)
        {
        }

        protected EventNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}