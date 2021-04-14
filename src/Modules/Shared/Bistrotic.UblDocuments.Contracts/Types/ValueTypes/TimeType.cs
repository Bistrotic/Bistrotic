namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable]
    public class TimeType : IXmlSerializable
    {
        public TimeType(string value) => ValueString = value;
        public TimeType(DateTimeOffset value) => _value = value;
        public TimeType(DateTime value) => _value = value;
        public TimeType() { }
        private DateTimeOffset _value;
        [XmlText]
        public string ValueString
        {
            get => XmlConvert.ToString(_value).Split('T')[^1];
            set => _value = XmlConvert.ToDateTimeOffset(value);
        }

        public static implicit operator DateTime(TimeType value) => value._value.LocalDateTime;
        public static implicit operator DateTimeOffset(TimeType value) => value._value;
        public static implicit operator string(TimeType value) => value.ValueString;
        public static implicit operator TimeType(DateTime value) => new(value);
        public static implicit operator TimeType(DateTimeOffset value) => new(value);
        public static implicit operator TimeType(string value) => new(value);
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

