namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(AccountingSupplierParty), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(AccountingSupplierParty), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class AccountingSupplierParty
    {
        [XmlElement(nameof(AccountingContact), Order = 5)]
        public string AccountingContact { get; set; } = string.Empty;

        [XmlElement(nameof(AdditionalAccountID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public IEnumerable<string> AdditionalAccountID { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(CustomerAssignedAccountID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string CustomerAssignedAccountID { get; set; } = string.Empty;

        [XmlElement(nameof(DataSendingCapability), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string DataSendingCapability { get; set; } = string.Empty;

        [XmlElement(nameof(DespatchContact), Order = 4)]
        public string DespatchContact { get; set; } = string.Empty;

        [XmlElement(nameof(Party), Order = 3)]
        public string Party { get; set; } = string.Empty;

        [XmlElement(nameof(SellerContact), Order = 6)]
        public string SellerContact { get; set; } = string.Empty;
    }
}