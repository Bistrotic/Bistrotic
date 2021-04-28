namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Entry", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Entry", Namespace = MxNamespaces.Fx)]
    public class DictionaryEntry
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlAttribute("k")]
        public string Key { get; set; } = string.Empty;

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlAttribute("v")]
        public string? Value { get; set; }
    }
}
