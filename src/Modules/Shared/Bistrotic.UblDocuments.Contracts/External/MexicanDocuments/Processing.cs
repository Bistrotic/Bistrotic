namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Procesamiento", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Procesamiento", Namespace = MxNamespaces.Fx)]
    public class Processing
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0)]
        public DictionarySet? Dictionary { get; set; } = new();
    }
}
