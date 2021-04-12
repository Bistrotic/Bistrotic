namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(
    "DeliveryTerms",
    Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot(
    "DeliveryTerms",
    Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
    IsNullable = false)]
    public class DeliveryTerms
    {
        [XmlElement("AllowanceCharge", Order = 6)]
        public string AllowanceCharge { get; set; } = string.Empty;

        [XmlElement("Amount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public decimal Amount { get; set; }

        [XmlElement("DeliveryLocation", Order = 5)]
        public string DeliveryLocation { get; set; } = string.Empty;

        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement("LossRisk", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public IEnumerable<string> LossRisk { get; set; } = Array.Empty<string>();

        [XmlElement("LossRiskResponsibilityCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
        public string LossRiskResponsibilityCode { get; set; } = string.Empty;

        [XmlElement("SpecialTerms", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
        public IEnumerable<string> SpecialTerms { get; set; } = Array.Empty<string>();
    }
}