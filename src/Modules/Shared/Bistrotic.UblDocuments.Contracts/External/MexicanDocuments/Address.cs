namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("DomicilioMexicano", Namespace = MxNamespaces.Fx)]
    [XmlRoot("DomicilioMexicano", Namespace = MxNamespaces.Fx)]
    public class Address
    {
        [DataMember(Order = 0)]
        [XmlElement("Calle", Order = 0)]
        public string? Street { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("NumeroExterior", Order = 1)]
        public string? StreetNumber { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("NumeroInterior", Order = 2)]
        public string? AppartmentNumber { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("Colonia", Order = 3)]
        public string? CityLocation { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("Municipio", Order = 4)]
        public string? City { get; set; }

        [DataMember(Order = 5)]
        [XmlElement("Estado", Order = 5)]
        public string? CountryLocation { get; set; }

        [DataMember(Order = 6)]
        [XmlElement("Pais", Order = 6)]
        public string? Country { get; set; }

        [DataMember(Order = 7)]
        [XmlElement("CodigoPostal", Order = 7)]
        public string? ZipCode { get; set; }

    }
}
