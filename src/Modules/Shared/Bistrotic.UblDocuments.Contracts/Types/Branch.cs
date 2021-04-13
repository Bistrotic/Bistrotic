namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(Branch), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(Branch), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class Branch
    {
        [XmlElement(nameof(Address), Order = 3)]
        public Address Address { get; set; } = new();

        [XmlElement(nameof(FinancialInstitution), Order = 2)]
        public FinancialInstitution FinancialInstitution { get; set; } = new();

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(Name), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string Name { get; set; } = string.Empty;
    }
}