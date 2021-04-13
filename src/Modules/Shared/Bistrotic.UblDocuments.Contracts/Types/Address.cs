namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(Address), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(Address), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class Address
    {
        [XmlElement(nameof(AdditionalStreetName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 7)]
        public string AdditionalStreetName { get; set; } = string.Empty;

        [XmlElement(nameof(AddressFormatCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string AddressFormatCode { get; set; } = string.Empty;

        [XmlElement(nameof(AddressLine), Order = 24)]
        public IEnumerable<AddressLine> AddressLine { get; set; } = Array.Empty<AddressLine>();

        [XmlElement(nameof(AddressTypeCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string AddressTypeCode { get; set; } = string.Empty;

        [XmlElement(nameof(BlockName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 8)]
        public string BlockName { get; set; } = string.Empty;

        [XmlElement(nameof(BuildingName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 9)]
        public string BuildingName { get; set; } = string.Empty;

        [XmlElement(nameof(BuildingNumber), Namespace = UblNamespaces.CommonBasicComponents2, Order = 10)]
        public string BuildingNumber { get; set; } = string.Empty;

        [XmlElement(nameof(CityName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 17)]
        public string CityName { get; set; } = string.Empty;

        [XmlElement(nameof(CitySubdivisionName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 16)]
        public string CitySubdivisionName { get; set; } = string.Empty;

        [XmlElement(nameof(Country), Order = 25)]
        public Country Country { get; set; } = new();

        [XmlElement(nameof(CountrySubentity), Namespace = UblNamespaces.CommonBasicComponents2, Order = 19)]
        public string CountrySubentity { get; set; } = string.Empty;

        [XmlElement(nameof(CountrySubentityCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 20)]
        public string CountrySubentityCode { get; set; } = string.Empty;

        [XmlElement(nameof(Department), Namespace = UblNamespaces.CommonBasicComponents2, Order = 12)]
        public string Department { get; set; } = string.Empty;

        [XmlElement(nameof(District), Namespace = UblNamespaces.CommonBasicComponents2, Order = 22)]
        public string District { get; set; } = string.Empty;

        [XmlElement(nameof(Floor), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public string Floor { get; set; } = string.Empty;

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(InhouseMail), Namespace = UblNamespaces.CommonBasicComponents2, Order = 11)]
        public string InhouseMail { get; set; } = string.Empty;

        [XmlElement(nameof(LocationCoordinate), Order = 26)]
        public IEnumerable<LocationCoordinate> LocationCoordinate { get; set; } = Array.Empty<LocationCoordinate>();

        [XmlElement(nameof(MarkAttention), Namespace = UblNamespaces.CommonBasicComponents2, Order = 13)]
        public string MarkAttention { get; set; } = string.Empty;

        [XmlElement(nameof(MarkCare), Namespace = UblNamespaces.CommonBasicComponents2, Order = 14)]
        public string MarkCare { get; set; } = string.Empty;

        [XmlElement(nameof(PlotIdentification), Namespace = UblNamespaces.CommonBasicComponents2, Order = 15)]
        public string PlotIdentification { get; set; } = string.Empty;

        [XmlElement(nameof(PostalZone), Namespace = UblNamespaces.CommonBasicComponents2, Order = 18)]
        public string PostalZone { get; set; } = string.Empty;

        [XmlElement(nameof(Postbox), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public string Postbox { get; set; } = string.Empty;

        [XmlElement(nameof(Region), Namespace = UblNamespaces.CommonBasicComponents2, Order = 21)]
        public string Region { get; set; } = string.Empty;

        [XmlElement(nameof(Room), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string Room { get; set; } = string.Empty;

        [XmlElement(nameof(StreetName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string StreetName { get; set; } = string.Empty;

        [XmlElement(nameof(TimezoneOffset), Namespace = UblNamespaces.CommonBasicComponents2, Order = 23)]
        public string TimezoneOffset { get; set; } = string.Empty;
    }
}