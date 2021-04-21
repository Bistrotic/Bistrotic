namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Conceptos", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Conceptos", Namespace = MxNamespaces.Cfdi)]
    public class TaxItems
    {

        [DataMember(Order = 0)]
        [XmlElement("Concepto", Order = 0, Namespace = MxNamespaces.Cfdi)]
        public List<TaxItem> Items { get; set; } = new();


    }
}
