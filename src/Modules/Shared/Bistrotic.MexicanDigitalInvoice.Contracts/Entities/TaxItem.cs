namespace Bistrotic.MexicanDigitalInvoice.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Concepto", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Concepto", Namespace = MxNamespaces.Cfdi)]
    public class TaxItem
    {
        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement("InformacionAduanera", Order = 1)]
        public string? CustomsInformation { get; set; }

        [DataMember(Order = 100)]
        [XmlAttribute("ClaveProdServ")]
        public string? ItemCode { get; set; }

        [DataMember(Order = 104)]
        [XmlAttribute("Descripcion")]
        public string? ItemName { get; set; }

        [DataMember(Order = 105)]
        [XmlAttribute("ValorUnitario")]
        public string? Price { get; set; }

        [DataMember(Order = 101)]
        [XmlAttribute("Cantidad")]
        public decimal Quantity { get; set; }

        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("Impuestos", Order = 0)]
        public Tax? Tax { get; set; }

        [DataMember(Order = 106)]
        [XmlAttribute("Importe")]
        public string? TotalAmount { get; set; }

        [DataMember(Order = 102)]
        [XmlAttribute("ClaveUnidad")]
        public string? UnitCode { get; set; }

        [DataMember(Order = 103)]
        [XmlAttribute("Unidad")]
        public string? UnitName { get; set; }
    }
}