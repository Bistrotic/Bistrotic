namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("TimbreFiscalDigital", Namespace = MxNamespaces.Tfd)]
    [XmlRoot("TimbreFiscalDigital", Namespace = MxNamespaces.Tfd)]
    public class RevenueStamp
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlAttribute]
        public string? Version { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlAttribute()]
        public string? UUID { get; set; }
    }
}
