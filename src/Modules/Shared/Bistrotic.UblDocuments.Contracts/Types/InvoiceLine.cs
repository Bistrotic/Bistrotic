namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(InvoiceLine), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(InvoiceLine), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class InvoiceLine
    {
        [XmlElement(nameof(AccountingCost), Namespace = UblNamespaces.CommonBasicComponents2, Order = 7)]
        public string AccountingCost { get; set; } = string.Empty;

        [XmlElement(nameof(AccountingCostCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string AccountingCostCode { get; set; } = string.Empty;

        [XmlElement(nameof(AllowanceCharge), Order = 20)]
        public IEnumerable<string> AllowanceCharge { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(BillingReference), Order = 14)]
        public IEnumerable<string> BillingReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(Delivery), Order = 18)]
        public IEnumerable<string> Delivery { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(DeliveryTerms), Order = 25)]
        public IEnumerable<string> DeliveryTerms { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(DespatchLineReference), Order = 12)]
        public IEnumerable<string> DespatchLineReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(DocumentReference), Order = 15)]
        public string[] DocumentReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(FreeOfChargeIndicator), Namespace = UblNamespaces.CommonBasicComponents2, Order = 9)]
        public string FreeOfChargeIndicator { get; set; } = string.Empty;

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(InvoicedQuantity), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public decimal InvoicedQuantity { get; set; }

        [XmlElement(nameof(InvoicePeriod), Order = 10)]
        public IEnumerable<string> InvoicePeriod { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(Item), Order = 23)]
        public string Item { get; set; } = string.Empty;

        [XmlElement(nameof(LineExtensionAmount), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public decimal LineExtensionAmount { get; set; }

        [XmlElement(nameof(Note), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public IEnumerable<string> Note { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(OrderLineReference), Order = 11)]
        public IEnumerable<string> OrderLineReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(OriginatorParty), Order = 17)]
        public string OriginatorParty { get; set; } = string.Empty;

        [XmlElement(nameof(PaymentPurposeCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 8)]
        public string PaymentPurposeCode { get; set; } = string.Empty;

        [XmlElement(nameof(PaymentTerms), Order = 19)]
        public IEnumerable<string> PaymentTerms { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(Price), Order = 24)]
        public decimal Price { get; set; }

        [XmlElement(nameof(PricingReference), Order = 16)]
        public string PricingReference { get; set; } = string.Empty;

        [XmlElement(nameof(ReceiptLineReference), Order = 13)]
        public IEnumerable<string> ReceiptLineReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(TaxPointDate), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public DateTimeOffset TaxPointDate { get; set; }

        [XmlElement(nameof(TaxTotal), Order = 21)]
        public IEnumerable<decimal> TaxTotal { get; set; } = Array.Empty<decimal>();

        [XmlElement(nameof(UUID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string UUID { get; set; } = string.Empty;

        [XmlElement(nameof(WithholdingTaxTotal), Order = 22)]
        public IEnumerable<decimal> WithholdingTaxTotal { get; set; } = Array.Empty<decimal>();
    }
}