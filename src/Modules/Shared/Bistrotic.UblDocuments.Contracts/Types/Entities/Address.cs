namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Name = nameof(Address), Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Address
    {
        [DataMember(Order = 7)]
        public string AdditionalStreetName { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string AddressFormatCode { get; set; } = string.Empty;

        [DataMember(Order = 24)]
        public IEnumerable<AddressLine> AddressLine { get; set; } = Array.Empty<AddressLine>();

        [DataMember(Order = 1)]
        public string AddressTypeCode { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        public string BlockName { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        public string BuildingName { get; set; } = string.Empty;

        [DataMember(Order = 10)]
        public string BuildingNumber { get; set; } = string.Empty;

        [DataMember(Order = 17)]
        public string CityName { get; set; } = string.Empty;

        [DataMember(Order = 16)]
        public string CitySubdivisionName { get; set; } = string.Empty;

        [DataMember(Order = 25)]
        public Country Country { get; set; } = new();

        [DataMember(Order = 19)]
        public string CountrySubentity { get; set; } = string.Empty;

        [DataMember(Order = 20)]
        public string CountrySubentityCode { get; set; } = string.Empty;

        [DataMember(Order = 12)]
        public string Department { get; set; } = string.Empty;

        [DataMember(Order = 22)]
        public string District { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string Floor { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 11)]
        public string InhouseMail { get; set; } = string.Empty;

        [DataMember(Order = 26)]
        public IEnumerable<LocationCoordinate> LocationCoordinate { get; set; } = Array.Empty<LocationCoordinate>();

        [DataMember(Order = 13)]
        public string MarkAttention { get; set; } = string.Empty;

        [DataMember(Order = 14)]
        public string MarkCare { get; set; } = string.Empty;

        [DataMember(Order = 15)]
        public string PlotIdentification { get; set; } = string.Empty;

        [DataMember(Order = 18)]
        public string PostalZone { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string Postbox { get; set; } = string.Empty;

        [DataMember(Order = 21)]
        public string Region { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string Room { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string StreetName { get; set; } = string.Empty;

        [DataMember(Order = 23)]
        public string TimezoneOffset { get; set; } = string.Empty;
    }
}