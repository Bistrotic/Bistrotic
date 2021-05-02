namespace Bistrotic.MexicanDigitalInvoice.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Impuestos", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Impuestos", Namespace = MxNamespaces.Cfdi)]
    public class Tax
    {
        [DataMember(Order = 100)]
        [XmlAttribute("TotalImpuestosTrasladados")]
        public decimal Total { get; set; }

        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("Traslados", Order = 0)]
        public TaxTransactions? Transactions { get; set; }
    }
}