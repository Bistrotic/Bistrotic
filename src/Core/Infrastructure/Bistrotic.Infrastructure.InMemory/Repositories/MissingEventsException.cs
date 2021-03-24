using System;
using System.Runtime.Serialization;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    [Serializable]
    internal class MissingEventsException<T> : Exception
    {
        public MissingEventsException()
        {
        }

        public MissingEventsException(string? message) : base(message)
        {
        }

        public MissingEventsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MissingEventsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}