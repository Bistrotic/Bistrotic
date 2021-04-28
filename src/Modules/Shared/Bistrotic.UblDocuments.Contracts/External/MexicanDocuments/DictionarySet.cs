namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Dictionary", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Dictionary", Namespace = MxNamespaces.Fx)]
    public class DictionarySet
    {
        [DataMember(Order = 100)]
        [XmlAttribute("name")]
        public string? Name { get; set; } = string.Empty;

        [XmlElement("Entry", Order = 0)]
        public List<DictionaryEntry> Entry { get; set; } = new();
    }
}
