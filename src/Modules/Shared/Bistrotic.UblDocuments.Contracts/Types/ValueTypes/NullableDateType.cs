namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Exceptions;

    [Serializable]
    public class NullableDateType : IXmlSerializable
    {
        private DateTimeOffset? _value;
        public NullableDateType() { }
        public NullableDateType(string? value)
        {
            ValueString = value;
        }
        public NullableDateType(DateTimeOffset? value) => _value = value;
        public NullableDateType(DateTime? value) => _value = value;
        public string? ValueString
        {
            get => (_value == null) ? null : XmlConvert.ToString(_value.Value, "yyyy-MM-dd");
            set
            {
                _value = string.IsNullOrWhiteSpace(value) ? null : XmlConvert.ToDateTimeOffset(value);
            }
        }

        public static implicit operator DateTime?(NullableDateType value) => value._value == null ? null : value._value.Value.LocalDateTime;
        public static implicit operator string?(NullableDateType value) => value.ValueString;
        public static implicit operator NullableDateType(DateTime? value) => new NullableDateType(value);
        public static implicit operator NullableDateType(string? value) => new NullableDateType(value);
        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            try
            {
                ValueString = reader.ReadElementContentAsString();
            }
            catch (Exception e)
            {
                throw new ReadDateTypeException(reader.LocalName, e);
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(ValueString);
        }
    }
}

