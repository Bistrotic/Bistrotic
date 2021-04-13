namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class CustomerParty
    {
        [DataMember(Order = 5)]
        public string AccountingContact { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public IEnumerable<string> AdditionalAccountID { get; set; } = Array.Empty<string>();

        [DataMember(Order = 6)]
        public string BuyerContact { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string CustomerAssignedAccountID { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string DeliveryContact { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string Party { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string SupplierAssignedAccountID { get; set; } = string.Empty;
    }
}