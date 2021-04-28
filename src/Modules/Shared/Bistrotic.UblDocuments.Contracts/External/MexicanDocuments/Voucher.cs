namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Comprobante", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Comprobante", Namespace = MxNamespaces.Cfdi)]
    public class Voucher
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("Emisor", Order = 0, Namespace = MxNamespaces.Cfdi)]
        public Issuer? Issuer { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement("Receptor", Order = 1, Namespace = MxNamespaces.Cfdi)]
        public Receiver? Receiver { get; set; }

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement("Conceptos", Order = 2, Namespace = MxNamespaces.Cfdi)]
        public TaxItems? TaxItems { get; set; }

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlElement("Impuestos", Order = 3, Namespace = MxNamespaces.Cfdi)]
        public Tax? Tax { get; set; }

        [DataMember(Order = 4), ProtoMember(4)]
        [XmlElement("Complemento", Order = 4, Namespace = MxNamespaces.Cfdi)]
        public Complement? Complement { get; set; }

        [DataMember(Order = 5), ProtoMember(5)]
        [XmlElement("Addenda", Order = 5, Namespace = MxNamespaces.Cfdi)]
        public Addendum? Addendum { get; set; }

        [DataMember(Order = 100)]
        [XmlAttribute("Folio")]
        public string? InvoiceId { get; set; }
    }
}
