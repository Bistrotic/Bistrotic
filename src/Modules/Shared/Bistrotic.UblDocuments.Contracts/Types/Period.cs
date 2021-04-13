namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlTypeAttribute("ActivityPeriod", Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRootAttribute("ActivityPeriod", Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class Period
    {
        [XmlElementAttribute("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 6)]
        public IEnumerable<string> Description { get; set; } = Array.Empty<string>();

        [XmlElementAttribute("DescriptionCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 5)]
        public IEnumerable<string> DescriptionCode { get; set; } = Array.Empty<string>();

        [XmlElementAttribute("DurationMeasure", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public decimal DurationMeasure { get; set; }

        [XmlElementAttribute("EndDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
        public DateTimeOffset EndDate { get; set; }

        [XmlElementAttribute("EndTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public DateTimeOffset EndTime { get; set; }

        [XmlElementAttribute("StartDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
        public DateTimeOffset StartDate { get; set; }

        [XmlElementAttribute("StartTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
        public DateTimeOffset StartTime { get; set; }
    }
}