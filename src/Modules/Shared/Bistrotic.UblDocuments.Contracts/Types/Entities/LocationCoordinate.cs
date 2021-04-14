namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class LocationCoordinate
    {
        [DataMember(Order = 7)]
        public decimal AltitudeMeasure { get; set; }

        [DataMember(Order = 0)]
        public string CoordinateSystemCode { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public decimal LatitudeDegreesMeasure { get; set; }

        [DataMember(Order = 3)]
        public string LatitudeDirectionCode { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public decimal LatitudeMinutesMeasure { get; set; }

        [DataMember(Order = 4)]
        public decimal LongitudeDegreesMeasure { get; set; }

        [DataMember(Order = 6)]
        public string LongitudeDirectionCode { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public decimal LongitudeMinutesMeasure { get; set; }
    }
}