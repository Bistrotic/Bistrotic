namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class NoteType
    {
        [XmlText]
        public string Value { get; set; } = string.Empty;
        [XmlAttribute(AttributeName = "languageID")]
        public string LanguageID { get; set; } = string.Empty;
    }
}
