namespace Bistrotic.Application.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class RepositoryReadFailedException : Exception
    {
        public RepositoryReadFailedException() : this(null)
        {
        }

        public RepositoryReadFailedException(string? message) : this(message, null)
        {
        }

        public RepositoryReadFailedException(string? message, Exception? innerException)
            : this(null, null, message, innerException)
        {
        }

        public RepositoryReadFailedException(string? id, string? repositoryName, string? message = null, Exception? innerException = null)
            : base($"Error reading state from repository. Id='{id}'; Repository:'{repositoryName}'.{message}", innerException)
        {
        }

        protected RepositoryReadFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}