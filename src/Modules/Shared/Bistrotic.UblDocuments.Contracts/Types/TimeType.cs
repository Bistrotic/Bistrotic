namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;
    [DataContract]
    public class TimeType
    {
        [XmlIgnore]
        private DateTimeOffset _value;
        [XmlText]
        public string ValueString
        {
            get
            {
                var val = XmlConvert.ToString(_value).Split('T');
                return val[^1];
            }
            set
            {
                _value = XmlConvert.ToDateTimeOffset(value);
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="TimeType"/> to <see cref="DateTime"/> in local time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateTime(TimeType value)
        {
            return (value == null) ? DateTime.MinValue : value._value.LocalDateTime;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="TimeType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TimeType(DateTime value)
        {
            return new TimeType { _value = value };
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TimeType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TimeType(string value) => new() { ValueString = value };
    }
}

