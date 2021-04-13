namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(DeliveryTerms), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(DeliveryTerms), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class DeliveryTerms
    {
        [XmlElement(nameof(AllowanceCharge), Order = 6)]
        public string AllowanceCharge { get; set; } = string.Empty;

        [XmlElement(nameof(Amount), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public decimal Amount { get; set; }

        [XmlElement(nameof(DeliveryLocation), Order = 5)]
        public string DeliveryLocation { get; set; } = string.Empty;

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(LossRisk), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public IEnumerable<string> LossRisk { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(LossRiskResponsibilityCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string LossRiskResponsibilityCode { get; set; } = string.Empty;

        [XmlElement(nameof(SpecialTerms), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public IEnumerable<string> SpecialTerms { get; set; } = Array.Empty<string>();
    }
}