namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(FinancialAccount), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(FinancialAccount), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class FinancialAccount
    {
        [XmlElement(nameof(AccountFormatCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public string AccountFormatCode { get; set; } = string.Empty;

        [XmlElement(nameof(AccountTypeCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public string AccountTypeCode { get; set; } = string.Empty;

        [XmlElement(nameof(AliasName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string AliasName { get; set; } = string.Empty;

        [XmlElement(nameof(Country), Order = 8)]
        public Country Country { get; set; } = new();

        [XmlElement(nameof(CurrencyCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string CurrencyCode { get; set; } = string.Empty;

        [XmlElement(nameof(FinancialInstitutionBranch), Order = 7)]
        public Branch FinancialInstitutionBranch { get; set; } = new();

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(Name), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string Name { get; set; } = string.Empty;

        [XmlElement(nameof(PaymentNote), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string PaymentNote { get; set; } = string.Empty;
    }
}