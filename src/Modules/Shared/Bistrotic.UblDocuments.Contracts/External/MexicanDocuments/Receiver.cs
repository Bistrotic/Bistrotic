namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Receptor", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Receptor", Namespace = MxNamespaces.Cfdi)]
    public class Receiver
    {
        [DataMember(Order = 0)]
        [XmlAttribute("Rfc")]
        public string? Code { get; set; }

        [DataMember(Order = 1)]
        [XmlAttribute("Nombre")]
        public string? Name { get; set; }

        [DataMember(Order = 2)]
        [XmlAttribute("UsoCFDI")]
        public string? UsageCode { get; set; }
    }
}
