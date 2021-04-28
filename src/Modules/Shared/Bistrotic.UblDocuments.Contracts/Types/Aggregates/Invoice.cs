namespace Bistrotic.UblDocuments.Types.Aggregates
{
    using Bistrotic.UblDocuments.Types.Entities;
    using Bistrotic.UblDocuments.Types.ValueTypes;

    using ProtoBuf;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType(Namespace = UblNamespaces.Invoice2)]
    [XmlRoot(Namespace = UblNamespaces.Invoice2)]
    public class Invoice : EntityBase
    {
        [Key]
        [XmlIgnore]
        [IgnoreDataMember]
        public int InvoiceId { get; set; }

        [NotMapped]
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public UBLExtensions? UBLExtensions { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? UBLVersionID { get; set; } = string.Empty;

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CustomizationID { get; set; } = string.Empty;

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ProfileID { get; set; } = string.Empty;

        [DataMember(Order = 4), ProtoMember(4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ProfileExecutionID { get; set; } = string.Empty;

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement(Order = 5, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; } = string.Empty;

        [DataMember(Order = 6), ProtoMember(6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool CopyIndicator { get; set; }

        [DataMember(Order = 7), ProtoMember(7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? UUID { get; set; }

        [DataMember(Order = 8, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? IssueDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 8, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? IssueDate
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value);
            set => IssueDateTime = (value == null) ? null : (DateTime)value;
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? IssueTime
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value.ToLocalTime());
            set => Time.SetTime(IssueDateTime, value);
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? DueDate
        {
            get => (DueDateTime == null) ? null : new(DueDateTime.Value);
            set => DueDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 10), ProtoMember(10)]
        [XmlIgnore]
        public DateTimeOffset? DueDateTime { get; set; }

        [DataMember(Order = 11), ProtoMember(11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? InvoiceTypeCode { get; set; }

        [DataMember(Order = 12), ProtoMember(12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Note { get; set; }

        [DataMember(Order = 13, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? TaxPointDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 13, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? TaxPointDate
        {
            get => (TaxPointDateTime == null) ? null : new(TaxPointDateTime.Value);
            set => TaxPointDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 14), ProtoMember(14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? DocumentCurrencyCode { get; set; }

        [DataMember(Order = 15), ProtoMember(15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? TaxCurrencyCode { get; set; }

        [DataMember(Order = 16), ProtoMember(16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? PricingCurrencyCode { get; set; }

        [DataMember(Order = 17), ProtoMember(17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? PaymentCurrencyCode { get; set; }

        [DataMember(Order = 18), ProtoMember(18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? PaymentAlternativeCurrencyCode { get; set; }

        [DataMember(Order = 19), ProtoMember(19)]
        [XmlElement(Order = 19, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public string? AccountingCostCode { get; set; }

        [DataMember(Order = 20), ProtoMember(20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? AccountingCost { get; set; } = string.Empty;

        [DataMember(Order = 21), ProtoMember(21)]
        [XmlElement(Order = 21, Namespace = UblNamespaces.CommonBasicComponents2)]
        public int LineCountNumeric { get; set; }

        [DataMember(Order = 22), ProtoMember(22)]
        [XmlElement(Order = 22, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? BuyerReference { get; set; } = string.Empty;

        [DataMember(Order = 23, IsRequired = true)]
        [XmlElement(Order = 23, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period InvoicePeriod { get; set; } = new();

        [DataMember(Order = 24), ProtoMember(24)]
        [XmlElement(Order = 24, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public OrderReference OrderReference { get; set; } = new();

        [DataMember(Order = 25), ProtoMember(25)]
        [XmlElement(Order = 25, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<BillingReference> BillingReference { get; set; } = new();

        [DataMember(Order = 26), ProtoMember(26)]
        [XmlElement(Order = 26, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DocumentReference DespatchDocumentReference { get; set; } = new();

        [DataMember(Order = 27), ProtoMember(27)]
        [XmlElement(Order = 27, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ReceiptDocumentReference { get; set; } = new();

        [DataMember(Order = 28), ProtoMember(28)]
        [XmlElement(Order = 28, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> StatementDocumentReference { get; set; } = new();

        [DataMember(Order = 29), ProtoMember(29)]
        [XmlElement(Order = 29, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> OriginatorDocumentReference { get; set; } = new();

        [DataMember(Order = 30), ProtoMember(30)]
        [XmlElement(Order = 30, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ContractDocumentReference { get; set; } = new();

        [DataMember(Order = 31), ProtoMember(31)]
        [XmlElement(Order = 31, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> AdditionalDocumentReference { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 32), ProtoMember(32)]
        [XmlElement(Order = 32, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<ProjectReference> ProjectReference { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 34, IsRequired = true)]
        [XmlElement(Order = 34, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public SupplierParty AccountingSupplierParty { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 35, IsRequired = true)]
        [XmlElement(Order = 35, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public AccountingCustomerParty AccountingCustomerParty { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 36)]
        [XmlElement(Order = 36, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party PayeeParty { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 37)]
        [XmlElement(Order = 37, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party BuyerCustomerParty { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 38)]
        [XmlElement(Order = 38, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public SupplierParty SellerSupplierParty { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 39)]
        [XmlElement(Order = 39, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party TaxRepresentativeParty { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 40)]
        [XmlElement(Order = 40, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<Delivery> Delivery { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 41)]
        [XmlElement(Order = 41, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DeliveryTerms DeliveryTerms { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 42)]
        [XmlElement(Order = 42, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<PaymentMeans> PaymentMeans { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 43)]
        [XmlElement(Order = 43, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<PaymentTerms> PaymentTerms { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 44)]
        [XmlElement(Order = 44, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<PrepaidPayment> PrepaidPayment { get; set; } = new();

        [NotMapped]
        [DataMember(Order = 45)]
        [XmlElement(Order = 45, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<AllowanceCharge> AllowanceCharge { get; set; } = new();

        [DataMember(Order = 46)]
        [XmlElement(Order = 46, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal TaxExchangeRate { get; set; }

        [DataMember(Order = 47)]
        [XmlElement(Order = 47, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PricingExchangeRate { get; set; }

        [DataMember(Order = 48)]
        [XmlElement(Order = 48, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PaymentExchangeRate { get; set; }

        [DataMember(Order = 49)]
        [XmlElement(Order = 49, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PaymentAlternativeExchangeRate { get; set; }

        [NotMapped]
        [DataMember(Order = 51)]
        [XmlElement(Order = 51, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<TaxTotal> TaxTotal { get; set; } = new();

        [DataMember(Order = 52, IsRequired = true)]
        [XmlElement(Order = 52, IsNullable = false, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; } = new();

        [DataMember(Order = 53, IsRequired = true, Name = nameof(InvoiceLine))]
        [XmlElement(Order = 53, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<InvoiceLine> InvoiceLine { get; set; } = new();
    }
}