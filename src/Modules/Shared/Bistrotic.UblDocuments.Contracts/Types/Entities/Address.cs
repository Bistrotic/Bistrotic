namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Address
    {
        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AdditionalStreetName { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AddressFormatCode { get; set; } = string.Empty;

        [DataMember(Order = 24)]
        [XmlElement(Order = 24, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<AddressLine> AddressLine { get; set; } = Array.Empty<AddressLine>();

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AddressTypeCode { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string BlockName { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string BuildingName { get; set; } = string.Empty;

        [DataMember(Order = 10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string BuildingNumber { get; set; } = string.Empty;

        [DataMember(Order = 17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CityName { get; set; } = string.Empty;

        [DataMember(Order = 16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CitySubdivisionName { get; set; } = string.Empty;

        [DataMember(Order = 25)]
        [XmlElement(Order = 25, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Country Country { get; set; } = new();

        [DataMember(Order = 19)]
        [XmlElement(Order = 19, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CountrySubentity { get; set; } = string.Empty;

        [DataMember(Order = 20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CountrySubentityCode { get; set; } = string.Empty;

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Department { get; set; } = string.Empty;

        [DataMember(Order = 22)]
        [XmlElement(Order = 22, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string District { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Floor { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string InhouseMail { get; set; } = string.Empty;

        [DataMember(Order = 26)]
        [XmlElement(Order = 26, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<LocationCoordinate> LocationCoordinate { get; set; } = Array.Empty<LocationCoordinate>();

        [DataMember(Order = 13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string MarkAttention { get; set; } = string.Empty;

        [DataMember(Order = 14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string MarkCare { get; set; } = string.Empty;

        [DataMember(Order = 15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string PlotIdentification { get; set; } = string.Empty;

        [DataMember(Order = 18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string PostalZone { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Postbox { get; set; } = string.Empty;

        [DataMember(Order = 21)]
        [XmlElement(Order = 21, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Region { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Room { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string StreetName { get; set; } = string.Empty;

        [DataMember(Order = 23)]
        [XmlElement(Order = 23, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string TimezoneOffset { get; set; } = string.Empty;
    }
}