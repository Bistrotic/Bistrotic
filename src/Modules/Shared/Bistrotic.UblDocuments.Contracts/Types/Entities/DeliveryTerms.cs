namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class DeliveryTerms
    {
        [DataMember(Order = 6)]
        public string AllowanceCharge { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public decimal Amount { get; set; }

        [DataMember(Order = 5)]
        public string DeliveryLocation { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public IEnumerable<string> LossRisk { get; set; } = Array.Empty<string>();

        [DataMember(Order = 2)]
        public string LossRiskResponsibilityCode { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public IEnumerable<string> SpecialTerms { get; set; } = Array.Empty<string>();
    }
}