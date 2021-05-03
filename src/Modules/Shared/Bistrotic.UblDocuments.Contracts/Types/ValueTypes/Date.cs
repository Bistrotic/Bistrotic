namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class Date
    {
        private DateTimeOffset _value;

        public Date() => _value = DateTimeOffset.MinValue;

        public Date(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            ValueString = value;
        }

        public Date(DateTimeOffset value) => _value = value;

        public Date(DateTime value) => _value = value;

        [XmlText]
        public string ValueString
        {
            get => XmlConvert.ToString(_value, "yyyy-MM-dd");
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                _value = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
            }
        }

        public static implicit operator Date(DateTime value) => new(value);

        public static implicit operator Date(DateTimeOffset value) => new(value);

        public static implicit operator Date(string value) => new(value);

        public static implicit operator DateTime(Date value) => value._value.DateTime;

        public static implicit operator DateTimeOffset(Date value) => value._value;

        public static implicit operator string(Date value) => value.ValueString;
    }
}