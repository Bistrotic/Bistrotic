namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    [Serializable]
    [DataContract]
    public class DateType
    {
        [IgnoreDataMember]
        private DateTimeOffset? _value;

        [IgnoreDataMember]
        public string ValueString
        {
            get => (_value == null) ? string.Empty : XmlConvert.ToString(_value.Value, "yyyy-MM-dd");
            set => _value = string.IsNullOrWhiteSpace(value) ? null : XmlConvert.ToDateTimeOffset(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateType"/> to <see cref="DateTime"/> in local time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateTime(DateType value)
        {
            return (value?._value == null) ? DateTime.MinValue : value._value.Value.LocalDateTime;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="DateType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateType(DateTime value)
        {
            return new DateType { _value = value };
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="DateType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateType(string value)
            => new() { ValueString = value };
    }
}

