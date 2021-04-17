namespace Bistrotic.UblDocuments.Types.Aggregates
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.Entities;
    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract]
    [XmlType(Namespace = UblNamespaces.Invoice2)]
    [XmlRoot(Namespace = UblNamespaces.Invoice2)]
    [KnownType(typeof(List<>))]
    public class Invoice
    {
        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string UBLVersionID { get; set; } = string.Empty;

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement(Order = 5, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 8, IsRequired = true)]
        [XmlElement(Order = 8, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date IssueDate { get; set; } = new();

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? IssueTime { get; set; }

        [DataMember(Order = 10, Name = nameof(DueDate))]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? DueDate { get; set; }

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonBasicComponents2)]
        public InvoiceTypeCode InvoiceTypeCode { get; set; } = new();

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Note? Note { get; set; }

        [DataMember(Order = 13, IsRequired = true)]
        [XmlElement(Order = 13, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date TaxPointDate { get; set; } = new();

        [DataMember(Order = 14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Code? DocumentCurrencyCode { get; set; } = new();

        [DataMember(Order = 23, IsRequired = true)]
        [XmlElement(Order = 23, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? InvoicePeriod { get; set; } = new();

        [DataMember(Order = 20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? AccountingCost { get; set; } = string.Empty;

        [DataMember(Order = 24)]
        [XmlElement(Order = 24, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public OrderReference OrderReference { get; set; } = new();

        [DataMember(Order = 26)]
        [XmlElement(Order = 26, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DocumentReference? DespatchDocumentReference { get; set; } = new();

        [DataMember(Order = 27)]
        [XmlElement(Order = 27, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ReceiptDocumentReference { get; set; } = new();

        [DataMember(Order = 28)]
        [XmlElement(Order = 28, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> StatementDocumentReference { get; set; } = new();

        [DataMember(Order = 29)]
        [XmlElement(Order = 29, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> OriginatorDocumentReference { get; set; } = new();

        [DataMember(Order = 30)]
        [XmlElement(Order = 30, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ContractDocumentReference { get; set; } = new();

        [DataMember(Order = 31)]
        [XmlElement(Order = 31, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> AdditionalDocumentReference { get; set; } = new();

        [DataMember(Order = 34, IsRequired = true)]
        [XmlElement(Order = 34, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public SupplierParty AccountingSupplierParty { get; set; } = new();

        [DataMember(Order = 35, IsRequired = true)]
        [XmlElement(Order = 35, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public AccountingCustomerParty AccountingCustomerParty { get; set; } = new();

        [DataMember(Order = 52, IsRequired = true)]
        [XmlElement(Order = 52, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; } = new();

        [DataMember(Order = 53, IsRequired = true, Name = nameof(InvoiceLine))]
        [XmlElement(Order = 53, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<InvoiceLine> InvoiceLine { get; set; } = new();

        [DataMember(Order = 36)]
        [XmlElement(Order = 36, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? PayeeParty { get; set; }

        [DataMember(Order = 19)]
        [XmlElement(Order = 19, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public AccountingCostCodeType? AccountingCostCode { get; set; }

        [DataMember(Order = 25)]
        [XmlElement(Order = 25, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> BillingReference { get; set; } = new();

        [DataMember(Order = 37)]
        [XmlElement(Order = 37, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? BuyerCustomerParty { get; set; }

        [DataMember(Order = 22)]
        [XmlElement(Order = 22, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? BuyerReference { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool CopyIndicator { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CustomizationID { get; set; } = string.Empty;

        [DataMember(Order = 40)]
        [XmlElement(Order = 40, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<Delivery> Delivery { get; set; } = new();

        [DataMember(Order = 41)]
        [XmlElement(Order = 41, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DeliveryTerms? DeliveryTerms { get; set; } = new();

        [DataMember(Order = 21)]
        [XmlElement(Order = 21, Namespace = UblNamespaces.CommonBasicComponents2)]
        public int LineCountNumeric { get; set; }

        [DataMember(Order = 18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Code? PaymentAlternativeCurrencyCode { get; set; }

        [DataMember(Order = 49)]
        [XmlElement(Order = 49, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PaymentAlternativeExchangeRate { get; set; }

        [DataMember(Order = 17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Code? PaymentCurrencyCode { get; set; }

        [DataMember(Order = 48)]
        [XmlElement(Order = 48, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PaymentExchangeRate { get; set; }

        [DataMember(Order = 16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Code? PricingCurrencyCode { get; set; }

        [DataMember(Order = 47)]
        [XmlElement(Order = 47, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PricingExchangeRate { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ProfileExecutionID { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ProfileID { get; set; } = string.Empty;

        [DataMember(Order = 32)]
        [XmlElement(Order = 32, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<ProjectReference> ProjectReference { get; set; } = new();


        [DataMember(Order = 38)]
        [XmlElement(Order = 38, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public SupplierParty? SellerSupplierParty { get; set; } = new();

        [DataMember(Order = 15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Code? TaxCurrencyCode { get; set; }

        [DataMember(Order = 46)]
        [XmlElement(Order = 46, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal TaxExchangeRate { get; set; }

        [DataMember(Order = 39)]
        [XmlElement(Order = 39, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? TaxRepresentativeParty { get; set; }

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? UUID { get; set; }
    }
}