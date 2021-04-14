namespace Bistrotic.UblDocuments.Types.Aggregates
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Bistrotic.UblDocuments.Types.Entities;
    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract(Namespace = "")]
    public class Invoice
    {
        [DataMember(Order = 5, IsRequired = true)]
        public string ID { get; set; } = string.Empty;
        [DataMember(Name = nameof(DueDate), Order = 10)]
        public DateType? DueDate { get; set; }
        [DataMember(Order = 8, IsRequired = true)]
        public DateType IssueDate { get; set; } = new();

        [DataMember(Order = 23, IsRequired = true)]
        public Period? InvoicePeriod { get; set; } = new();

        [DataMember(Order = 9)]
        public TimeType? IssueTime { get; set; }

        [DataMember(Order = 20)]
        public string AccountingCost { get; set; } = string.Empty;

        [DataMember(Order = 19)]
        public string AccountingCostCode { get; set; } = string.Empty;

        [DataMember(Order = 35)]
        public CustomerParty AccountingCustomerParty { get; set; } = new();

        [DataMember(Order = 34)]
        public AccountingSupplierParty AccountingSupplierParty { get; set; } = new();

        [DataMember(Order = 25)]
        public IEnumerable<string> BillingReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 37)]
        public CustomerParty BuyerCustomerParty { get; set; } = new();

        [DataMember(Order = 22)]
        public string BuyerReference { get; set; } = string.Empty;

        [DataMember(Order = 30)]
        public IEnumerable<string> ContractDocumentReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 6)]
        public string CopyIndicator { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string CustomizationID { get; set; } = string.Empty;

        [DataMember(Order = 40)]
        public IEnumerable<string> Delivery { get; set; } = Array.Empty<string>();

        [DataMember(Order = 41)]
        public DeliveryTerms DeliveryTerms { get; set; } = new();

        [DataMember(Order = 26)]
        public IEnumerable<string> DespatchDocumentReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 14)]
        public string DocumentCurrencyCode { get; set; } = string.Empty;

        [DataMember(Order = 53)]
        public IEnumerable<InvoiceLine> InvoiceLine { get; set; } = Array.Empty<InvoiceLine>();

        [DataMember(Order = 11)]
        public string InvoiceTypeCode { get; set; } = string.Empty;

        [DataMember(Order = 52)]
        public decimal LegalMonetaryTotal { get; set; }

        [DataMember(Order = 21)]
        public int LineCountNumeric { get; set; }

        [DataMember(Order = 12)]
        public IEnumerable<string> Note { get; set; } = Array.Empty<string>();

        [DataMember(Order = 24)]
        public string OrderReference { get; set; } = string.Empty;

        [DataMember(Order = 29)]
        public IEnumerable<string> OriginatorDocumentReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 36)]
        public string PayeeParty { get; set; } = string.Empty;

        [DataMember(Order = 18)]
        public string PaymentAlternativeCurrencyCode { get; set; } = string.Empty;

        [DataMember(Order = 49)]
        public decimal PaymentAlternativeExchangeRate { get; set; }

        [DataMember(Order = 17)]
        public string PaymentCurrencyCode { get; set; } = string.Empty;

        [DataMember(Order = 48)]
        public decimal PaymentExchangeRate { get; set; }

        [DataMember(Order = 16)]
        public string PricingCurrencyCode { get; set; } = string.Empty;

        [DataMember(Order = 47)]
        public decimal PricingExchangeRate { get; set; }

        [DataMember(Order = 4)]
        public string ProfileExecutionID { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string ProfileID { get; set; } = string.Empty;

        [DataMember(Order = 32)]
        public IEnumerable<string> ProjectReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 27)]
        public IEnumerable<string> ReceiptDocumentReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 38)]
        public AccountingSupplierParty SellerSupplierParty { get; set; } = new();

        [DataMember(Order = 15)]
        public string TaxCurrencyCode { get; set; } = string.Empty;

        [DataMember(Order = 46)]
        public decimal TaxExchangeRate { get; set; }

        [DataMember(Order = 13)]
        public DateTimeOffset TaxPointDate { get; set; }

        [DataMember(Order = 39)]
        public string TaxRepresentativeParty { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string UBLVersionID { get; set; } = string.Empty;

        [DataMember(Order = 7)]
        public string UUID { get; set; } = string.Empty;

    }
}