namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class Time
    {
        public Time(string value) => ValueString = value;
        public Time(DateTimeOffset value) => _value = value;
        public Time(DateTime value) => _value = value;
        public Time() { }
        private DateTimeOffset _value;
        [XmlText]
        public string ValueString
        {
            get => XmlConvert.ToString(_value).Split('T')[^1];
            set => _value = XmlConvert.ToDateTimeOffset(value);
        }

        public static implicit operator DateTime(Time value) => value._value.LocalDateTime;
        public static implicit operator DateTimeOffset(Time value) => value._value;
        public static implicit operator string(Time value) => value.ValueString;
        public static implicit operator Time(DateTime value) => new(value);
        public static implicit operator Time(DateTimeOffset value) => new(value);
        public static implicit operator Time(string value) => new(value);

    }
}

