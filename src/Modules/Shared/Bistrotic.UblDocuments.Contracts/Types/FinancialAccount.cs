namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class FinancialAccount
    {
        [DataMember(Order = 4)]
        public string AccountFormatCode { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string AccountTypeCode { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string AliasName { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        public Country Country { get; set; } = new();

        [DataMember(Order = 5)]
        public string CurrencyCode { get; set; } = string.Empty;

        [DataMember(Order = 7)]
        public Branch FinancialInstitutionBranch { get; set; } = new();

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string Name { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string PaymentNote { get; set; } = string.Empty;
    }
}