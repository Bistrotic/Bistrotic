namespace Bistrotic.MexicanDigitalInvoice.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class Note
    {
        [XmlAttribute(AttributeName = "languageID")]
        public string LanguageID { get; set; } = string.Empty;

        [XmlText]
        public string Value { get; set; } = string.Empty;
    }
}