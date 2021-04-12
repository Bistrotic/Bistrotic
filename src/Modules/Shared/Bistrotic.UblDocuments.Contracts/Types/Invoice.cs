namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    /// <summary>
    /// A document used to request payment.
    /// <para/>
    /// ComponentType: ABIE
    /// <para/>
    /// DictionaryEntryName: Invoice. Details
    /// <para/>
    /// ObjectClass: Invoice
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(Invoice), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    [XmlRoot(nameof(Invoice), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", IsNullable = false)]
    public class Invoice
    {
        [XmlElement(nameof(AccountingCost), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 20)]
        public string AccountingCost { get; set; } = string.Empty;

        [XmlElement(
                                            nameof(AccountingCostCode),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 19)]
        public string AccountingCostCode { get; set; } = string.Empty;

        [XmlElement(
            nameof(AccountingCustomerParty),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 35)]
        public CustomerParty AccountingCustomerParty { get; set; } = new();

        [XmlElement(
            nameof(AccountingSupplierParty),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 34)]
        public SupplierParty AccountingSupplierParty { get; set; } = new();

        [XmlElement(nameof(BillingReference), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 25)]
        public IEnumerable<string> BillingReference { get; set; } = Array.Empty<string>();

        [XmlElement(
                    nameof(BuyerCustomerParty),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 37)]
        public CustomerParty BuyerCustomerParty { get; set; } = new();

        [XmlElement(
            nameof(BuyerReference),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
            , Order = 22)]
        public string BuyerReference { get; set; } = string.Empty;

        [XmlElement(
                                                                    nameof(ContractDocumentReference),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
            , Order = 30)]
        public IEnumerable<string> ContractDocumentReference { get; set; } = Array.Empty<string>();

        [XmlElement(
            nameof(CopyIndicator),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
            , Order = 6)]
        public string CopyIndicator { get; set; } = string.Empty;

        [XmlElement(
            nameof(CustomizationID),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
            , Order = 2)]
        public string CustomizationID { get; set; } = string.Empty;

        [XmlElement(nameof(Delivery), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 40)]
        public IEnumerable<string> Delivery { get; set; } = Array.Empty<string>();

        [XmlElement(
            nameof(DeliveryTerms),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
            , Order = 41)]
        public DeliveryTerms DeliveryTerms { get; set; } = new();

        [XmlElement(nameof(DespatchDocumentReference), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 26)]
        public IEnumerable<string> DespatchDocumentReference { get; set; } = Array.Empty<string>();

        [XmlElement(
            nameof(DocumentCurrencyCode),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 14)]
        public string DocumentCurrencyCode { get; set; } = string.Empty;

        [XmlElement(
            nameof(DueDate),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
            , Order = 10)]
        public DateTimeOffset DueDate { get; set; }

        [XmlElement(
            nameof(ID),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 5)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(InvoiceLine), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 53)]
        public IEnumerable<InvoiceLine> InvoiceLine { get; set; } = Array.Empty<InvoiceLine>();

        [XmlElement(
                    nameof(InvoiceTypeCode),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 11)]
        public string InvoiceTypeCode { get; set; } = string.Empty;

        [XmlElement(
            nameof(IssueDate),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 8)]
        public DateTimeOffset IssueDate { get; set; }

        [XmlElement(
            nameof(IssueTime),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 9)]
        public DateTimeOffset IssueTime { get; set; }

        [XmlElement(
            nameof(LegalMonetaryTotal),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 52)]
        public decimal LegalMonetaryTotal { get; set; }

        [XmlElement(nameof(LineCountNumeric), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 21)]
        public int LineCountNumeric { get; set; }

        [XmlElement(nameof(Note), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 12)]
        public IEnumerable<string> Note { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(OrderReference), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 24)]
        public string OrderReference { get; set; } = string.Empty;

        [XmlElement(nameof(OriginatorDocumentReference), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 29)]
        public IEnumerable<string> OriginatorDocumentReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(PayeeParty), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 36)]
        public string PayeeParty { get; set; } = string.Empty;

        [XmlElement(nameof(PaymentAlternativeCurrencyCode), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 18)]
        public string PaymentAlternativeCurrencyCode { get; set; } = string.Empty;

        [XmlElement(nameof(PaymentAlternativeExchangeRate), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 49)]
        public decimal PaymentAlternativeExchangeRate { get; set; }

        [XmlElement(nameof(PaymentCurrencyCode), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 17)]
        public string PaymentCurrencyCode { get; set; } = string.Empty;

        [XmlElement(nameof(PaymentExchangeRate), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 48)]
        public decimal PaymentExchangeRate { get; set; }

        [XmlElement(nameof(PricingCurrencyCode), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 16)]
        public string PricingCurrencyCode { get; set; } = string.Empty;

        [XmlElement(nameof(PricingExchangeRate), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 47)]
        public decimal PricingExchangeRate { get; set; }

        [XmlElement(nameof(ProfileExecutionID), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public string ProfileExecutionID { get; set; } = string.Empty;

        [XmlElement(nameof(ProfileID), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public string ProfileID { get; set; } = string.Empty;

        [XmlElement(nameof(ProjectReference), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 32)]
        public IEnumerable<string> ProjectReference { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(ReceiptDocumentReference), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", Order = 27)]
        public IEnumerable<string> ReceiptDocumentReference { get; set; } = Array.Empty<string>();

        [XmlElement(
            nameof(SellerSupplierParty),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 38)]
        public SupplierParty SellerSupplierParty { get; set; } = new();

        [XmlElement(
            nameof(TaxCurrencyCode),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 15)]
        public string TaxCurrencyCode { get; set; } = string.Empty;

        [XmlElement(
            nameof(TaxExchangeRate),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 46)]
        public decimal TaxExchangeRate { get; set; }

        [XmlElement(
            nameof(TaxPointDate),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 13)]
        public DateTimeOffset TaxPointDate { get; set; }

        [XmlElement(
            nameof(TaxRepresentativeParty),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            Order = 39)]
        public string TaxRepresentativeParty { get; set; } = string.Empty;

        [XmlElement(
            nameof(UBLVersionID),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 1)]
        public string UBLVersionID { get; set; } = string.Empty;

        [XmlElement(
            nameof(UUID),
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 7)]
        public string UUID { get; set; } = string.Empty;
    }
}