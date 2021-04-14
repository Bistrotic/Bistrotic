namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable]
    public class DateType : IXmlSerializable
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

        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            ValueString = reader.ReadElementContentAsString();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(ValueString);
        }
    }
}

