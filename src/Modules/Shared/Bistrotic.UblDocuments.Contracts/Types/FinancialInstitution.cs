namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(FinancialInstitution), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(FinancialInstitution), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class FinancialInstitution
    {
        [XmlElement(nameof(Address), Order = 2)]
        public Address Address { get; set; } = new();

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(Name), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string Name { get; set; } = string.Empty;
    }
}