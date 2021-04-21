namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Traslados", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Traslados", Namespace = MxNamespaces.Cfdi)]
    public class TaxTransactions
    {
        [DataMember(Order = 0)]
        [XmlElement("Traslado", Order = 0)]
        public List<TaxTransaction> Transaction { get; set; } = new();
    }
}
