namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Exceptions;

    [Serializable]
    public class NullableTimeType : IXmlSerializable
    {
        public NullableTimeType(string? value) => ValueString = value;
        public NullableTimeType(DateTimeOffset? value) => _value = value;
        public NullableTimeType(DateTime? value) => _value = value;
        public NullableTimeType() { }
        private DateTimeOffset? _value;
        public string? ValueString
        {
            get => _value == null ? null : XmlConvert.ToString(_value.Value).Split('T')[^1];
            set => _value = value == null ? null : XmlConvert.ToDateTimeOffset(value);
        }

        public static implicit operator DateTime?(NullableTimeType value) => value._value?.LocalDateTime;
        public static implicit operator DateTimeOffset?(NullableTimeType value) => value._value;
        public static implicit operator string?(NullableTimeType value) => value.ValueString;
        public static implicit operator NullableTimeType(DateTime? value) => new(value);
        public static implicit operator NullableTimeType(DateTimeOffset? value) => new(value);
        public static implicit operator NullableTimeType(string? value) => new(value);
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

