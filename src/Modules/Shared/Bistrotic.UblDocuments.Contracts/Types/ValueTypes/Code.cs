namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class Code
    {
        [XmlText]
        public string Value { get; set; } = string.Empty;
        [XmlAttribute(AttributeName = "listID")]
        public string ListID { get; set; } = string.Empty;
        [XmlAttribute(AttributeName = "listAgencyID")]
        public string ListAgencyID { get; set; } = string.Empty;

    }
}

