namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType("InvoiceLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot("InvoiceLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public class InvoiceLine
    {
        [XmlElement("AccountingCost", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 7)]
        public string AccountingCost { get; set; } = string.Empty;

        [XmlElement("AccountingCostCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 6)]
        public string AccountingCostCode { get; set; } = string.Empty;

        [XmlElement("AllowanceCharge", Order = 20)]
        public IEnumerable<string> AllowanceCharge { get; set; } = Array.Empty<string>();

        [XmlElement("BillingReference", Order = 14)]
        public IEnumerable<string> BillingReference { get; set; } = Array.Empty<string>();

        [XmlElement("Delivery", Order = 18)]
        public IEnumerable<string> Delivery { get; set; } = Array.Empty<string>();

        [XmlElement("DeliveryTerms", Order = 25)]
        public IEnumerable<string> DeliveryTerms { get; set; } = Array.Empty<string>();

        [XmlElement("DespatchLineReference", Order = 12)]
        public IEnumerable<string> DespatchLineReference { get; set; } = Array.Empty<string>();

        [XmlElement("DocumentReference", Order = 15)]
        public string[] DocumentReference { get; set; } = Array.Empty<string>();

        [XmlElement("FreeOfChargeIndicator", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 9)]
        public string FreeOfChargeIndicator { get; set; } = string.Empty;

        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement("InvoicedQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public decimal InvoicedQuantity { get; set; }

        [XmlElement("InvoicePeriod", Order = 10)]
        public IEnumerable<string> InvoicePeriod { get; set; } = Array.Empty<string>();

        [XmlElement("Item", Order = 23)]
        public string Item { get; set; } = string.Empty;

        [XmlElement("LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public decimal LineExtensionAmount { get; set; }

        [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
        public IEnumerable<string> Note { get; set; } = Array.Empty<string>();

        [XmlElement("OrderLineReference", Order = 11)]
        public IEnumerable<string> OrderLineReference { get; set; } = Array.Empty<string>();

        [XmlElement("OriginatorParty", Order = 17)]
        public string OriginatorParty { get; set; } = string.Empty;

        [XmlElement("PaymentPurposeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 8)]
        public string PaymentPurposeCode { get; set; } = string.Empty;

        [XmlElement("PaymentTerms", Order = 19)]
        public IEnumerable<string> PaymentTerms { get; set; } = Array.Empty<string>();

        [XmlElement("Price", Order = 24)]
        public decimal Price { get; set; }

        [XmlElement("PricingReference", Order = 16)]
        public string PricingReference { get; set; } = string.Empty;

        [XmlElement("ReceiptLineReference", Order = 13)]
        public IEnumerable<string> ReceiptLineReference { get; set; } = Array.Empty<string>();

        [XmlElement("TaxPointDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 5)]
        public DateTimeOffset TaxPointDate { get; set; }

        [XmlElement("TaxTotal", Order = 21)]
        public IEnumerable<decimal> TaxTotal { get; set; } = Array.Empty<decimal>();

        [XmlElement("UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
        public string UUID { get; set; } = string.Empty;

        [XmlElement("WithholdingTaxTotal", Order = 22)]
        public IEnumerable<decimal> WithholdingTaxTotal { get; set; } = Array.Empty<decimal>();
    }
}