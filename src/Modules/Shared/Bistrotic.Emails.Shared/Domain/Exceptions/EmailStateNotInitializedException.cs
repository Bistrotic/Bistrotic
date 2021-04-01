using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bistrotic.Emails.Domain.Exceptions
{
    [Serializable]
    internal class EmailStateNotInitializedException : Exception
    {
        public EmailStateNotInitializedException()
        {
        }

        public EmailStateNotInitializedException(string? message) : base(message)
        {
        }

        public EmailStateNotInitializedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailStateNotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}