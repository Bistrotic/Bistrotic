namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class DateType
    {
        private DateTimeOffset _value;
        public DateType() => _value = DateTimeOffset.MinValue;
        public DateType(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            ValueString = value;
        }
        public DateType(DateTimeOffset value) => _value = value;
        public DateType(DateTime value) => _value = value;

        [XmlText]
        public string ValueString
        {
            get => XmlConvert.ToString(_value, "yyyy-MM-dd");
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                _value = XmlConvert.ToDateTimeOffset(value);
            }
        }

        public static implicit operator DateTime(DateType value) => value._value.LocalDateTime;
        public static implicit operator string(DateType value) => value.ValueString;
        public static implicit operator DateType(DateTime value) => new(value);
        public static implicit operator DateType(string value) => new(value);
    }
}

