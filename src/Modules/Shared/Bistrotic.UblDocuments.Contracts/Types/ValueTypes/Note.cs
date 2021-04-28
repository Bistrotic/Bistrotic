namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class Note
    {
        [XmlText]
        public string Value { get; set; } = string.Empty;
        [XmlAttribute(AttributeName = "languageID")]
        public string LanguageID { get; set; } = string.Empty;
    }
}
