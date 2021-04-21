namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Impuestos", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Impuestos", Namespace = MxNamespaces.Cfdi)]
    public class Tax
    {
        [DataMember(Order = 0)]
        [XmlElement("Traslados", Order = 0)]
        public TaxTransactions? Transactions { get; set; }

        [DataMember(Order = 100)]
        [XmlAttribute("TotalImpuestosTrasladados")]
        public decimal Total { get; set; }

    }
}
