using System;
using System.Runtime.Serialization;

#pragma warning disable RCS1194 // Implement exception constructors.

namespace Bistrotic.WorkItems.Application.Exceptions
{
    [Serializable]
    public class MissingSettingsException<TSettings> : Exception
    {
        public MissingSettingsException(string? missingProperty = null, string? message = null, Exception? innerException = null)
            : base($"The settings property {typeof(TSettings)}:{missingProperty} is not defined.{message}", innerException)
        {
        }

        protected MissingSettingsException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}