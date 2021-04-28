namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Emisor", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Emisor", Namespace = MxNamespaces.Fx)]
    public class Seller
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("DomicilioFiscal", Order = 0)]
        public Address? TaxResidence { get; set; }
    }
}
