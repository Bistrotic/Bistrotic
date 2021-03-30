using System;
using System.Runtime.Serialization;

namespace Bistrotic.Infrastructure.WebServer.Exceptions
{
    [Serializable]
    internal class ServerStartupNotInitializedException : Exception
    {
        public ServerStartupNotInitializedException() : this(null)
        {
        }

        public ServerStartupNotInitializedException(string? field) : this(field, null, null)
        {
        }

        public ServerStartupNotInitializedException(string? field, string? message, Exception? innerException)
            : base($"The startup class is not initialized. The field '{field}' is null.\n{message}", innerException)
        {
        }

        public ServerStartupNotInitializedException(string? message, Exception? innerException) : this(null, message, innerException)
        {
        }

        protected ServerStartupNotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}