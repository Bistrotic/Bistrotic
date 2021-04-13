namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(LocationCoordinate), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonAggregateComponents - 2")]
    [XmlRoot(nameof(LocationCoordinate), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonAggregateComponents - 2", IsNullable = false)]
    public class LocationCoordinate
    {
        [XmlElement(nameof(AltitudeMeasure), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 7)]
        public decimal AltitudeMeasure { get; set; }

        [XmlElement(nameof(CoordinateSystemCode), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 0)]
        public string CoordinateSystemCode { get; set; } = string.Empty;

        [XmlElement(nameof(LatitudeDegreesMeasure), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 1)]
        public decimal LatitudeDegreesMeasure { get; set; }

        [XmlElement(nameof(LatitudeDirectionCode), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 3)]
        public string LatitudeDirectionCode { get; set; } = string.Empty;

        [XmlElement(nameof(LatitudeMinutesMeasure), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 2)]
        public decimal LatitudeMinutesMeasure { get; set; }

        [XmlElement(nameof(LongitudeDegreesMeasure), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 4)]
        public decimal LongitudeDegreesMeasure { get; set; }

        [XmlElement(nameof(LongitudeDirectionCode), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 6)]
        public string LongitudeDirectionCode { get; set; } = string.Empty;

        [XmlElement(nameof(LongitudeMinutesMeasure), Namespace = "urn: oasis:names: specification:ubl: schema:xsd: CommonBasicComponents - 2", Order = 5)]
        public decimal LongitudeMinutesMeasure { get; set; }
    }
}