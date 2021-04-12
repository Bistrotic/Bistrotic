namespace Bistrotic.UblInvoices.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType("AccountingSupplierParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot("AccountingSupplierParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public class SupplierParty
    {
        [XmlElement(
            nameof(AccountingContact),
            Order = 5)]
        public string AccountingContact { get; set; } = string.Empty;

        [XmlElement(
            nameof(AdditionalAccountID),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 1)]
        public IEnumerable<string> AdditionalAccountID { get; set; } = Array.Empty<string>();

        [XmlElement(
            nameof(CustomerAssignedAccountID),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 0)]
        public string CustomerAssignedAccountID { get; set; } = string.Empty;

        [XmlElement(
            nameof(DataSendingCapability),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 2)]
        public string DataSendingCapability { get; set; } = string.Empty;

        [XmlElement(
            nameof(DespatchContact),
            Order = 4)]
        public string DespatchContact { get; set; } = string.Empty;

        [XmlElement(
            nameof(Party),
            Order = 3)]
        public string Party { get; set; } = string.Empty;

        [XmlElement(
            nameof(SellerContact),
            Order = 6)]
        public string SellerContact { get; set; } = string.Empty;
    }
}