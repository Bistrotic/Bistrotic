namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Name = nameof(AccountingSupplierParty), Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class AccountingSupplierParty
    {
        [DataMember(Order = 5)]
        public string AccountingContact { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public IEnumerable<string> AdditionalAccountID { get; set; } = Array.Empty<string>();

        [DataMember(Order = 0)]
        public string CustomerAssignedAccountID { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string DataSendingCapability { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string DespatchContact { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string Party { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string SellerContact { get; set; } = string.Empty;
    }
}