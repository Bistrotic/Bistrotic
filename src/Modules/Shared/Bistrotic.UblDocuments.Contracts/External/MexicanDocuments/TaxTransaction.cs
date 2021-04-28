namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Traslado", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Traslado", Namespace = MxNamespaces.Cfdi)]
    public class TaxTransaction
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlAttribute("Base")]
        public decimal Base { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlAttribute("Impuesto")]
        public string? TaxCode { get; set; }

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlAttribute("TipoFactor")]
        public string? FactorType { get; set; }

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlAttribute("TasaOCuota")]
        public decimal Percent { get; set; }

        [DataMember(Order = 4), ProtoMember(4)]
        [XmlAttribute("Importe")]
        public decimal Amount { get; set; }

    }
}
