namespace Bistrotic.MexicanDigitalInvoice.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Concepto", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Concepto", Namespace = MxNamespaces.Fx)]
    public class InvoiceLine
    {
        [DataMember(Order = 4), ProtoMember(5)]
        [XmlElement("Descripcion", Order = 4, Namespace = MxNamespaces.Fx)]
        public string Description { get; set; } = string.Empty;

        [DataMember(Order = 6), ProtoMember(7)]
        [XmlElement("Importe", Order = 6, Namespace = MxNamespaces.Fx)]
        public decimal LineAmount { get; set; }

        [DataMember(Order = 0), ProtoMember(1)]
        [XmlElement("Cantidad", Order = 0, Namespace = MxNamespaces.Fx)]
        public decimal Quantity { get; set; }
    }
}