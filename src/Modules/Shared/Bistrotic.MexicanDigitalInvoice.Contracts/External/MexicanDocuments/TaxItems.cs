namespace Bistrotic.MexicanDigitalInvoice.External.MexicanDocuments
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Conceptos", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Conceptos", Namespace = MxNamespaces.Cfdi)]
    public class TaxItems
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("Concepto", Order = 0, Namespace = MxNamespaces.Cfdi)]
        public List<TaxItem> Items { get; set; } = new();
    }
}