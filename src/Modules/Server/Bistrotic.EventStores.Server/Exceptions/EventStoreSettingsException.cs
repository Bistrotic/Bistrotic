namespace Bistrotic.EventStores.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class EventStoreSettingsException : Exception
    {
        public EventStoreSettingsException()
            : this(null)
        {
        }

        public EventStoreSettingsException(string? message)
            : this(message, null)
        {
        }

        public EventStoreSettingsException(string settingName, string? message, Exception? innerException = null)
            : base($"{message}\nFix the event store settings value '{nameof(EventStoresSettings)}:{nameof(EventStoresSettings.ConnectionString)}'.", innerException)
        {
        }

        public EventStoreSettingsException(string? message, Exception? innerException)
            : this(string.Empty, message, innerException)
        {
        }

        protected EventStoreSettingsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}