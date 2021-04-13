﻿namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(
    "AccountingCustomerParty",
    Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(
    "AccountingCustomerParty",
    Namespace = UblNamespaces.CommonAggregateComponents2,
    IsNullable = false)]
    public class CustomerParty
    {
        [XmlElement(
            "AccountingContact",
            Order = 5)]
        public string AccountingContact { get; set; } = string.Empty;

        [XmlElement(
            "AdditionalAccountID",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 2)]
        public IEnumerable<string> AdditionalAccountID { get; set; } = Array.Empty<string>();

        [XmlElement(
            "BuyerContact",
            Order = 6)]
        public string BuyerContact { get; set; } = string.Empty;

        [XmlElement(
            "CustomerAssignedAccountID",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 0)]
        public string CustomerAssignedAccountID { get; set; } = string.Empty;

        [XmlElement(
            "DeliveryContact",
            Order = 4)]
        public string DeliveryContact { get; set; } = string.Empty;

        [XmlElement(
            "Party",
            Order = 3)]
        public string Party { get; set; } = string.Empty;

        [XmlElement(
            "SupplierAssignedAccountID",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 1)]
        public string SupplierAssignedAccountID { get; set; } = string.Empty;
    }
}