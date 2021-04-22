namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Receptor", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Receptor", Namespace = MxNamespaces.Fx)]
    public class Customer
    {
        [DataMember(Order = 0)]
        [XmlElement("CdgPaisReceptor", Order = 0)]
        public string? CountryCode { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("RFCReceptor", Order = 1)]
        public string? Code { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("NombreReceptor", Order = 2)]
        public string? Name { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("Domicilio", Order = 3)]
        public Residence? Residence { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("UsoCFDI", Order = 4)]
        public string? UsageCode { get; set; }

    }
}
