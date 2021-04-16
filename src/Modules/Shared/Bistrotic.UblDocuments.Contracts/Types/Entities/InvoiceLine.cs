namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Namespace = "")]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class InvoiceLine
    {
        [DataMember(Order = 7)]
        public string AccountingCost { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string AccountingCostCode { get; set; } = string.Empty;

        [DataMember(Order = 15)]
        public string[] DocumentReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 9)]
        public string FreeOfChargeIndicator { get; set; } = string.Empty;

        [DataMember(Order = 0, IsRequired = true)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public decimal InvoicedQuantity { get; set; }

        [DataMember(Order = 4)]
        public decimal LineExtensionAmount { get; set; }
        /*
                 
        [DataMember(Order = 10)]
        public Period InvoicePeriod { get; set; } = new();

        [DataMember(Order = 23, IsRequired = true)]
        public Item Item { get; set; } = new();

        [DataMember(Order = 20)]
        public IEnumerable<string> AllowanceCharge { get; set; } = Array.Empty<string>();

        [DataMember(Order = 14)]
        public IEnumerable<string> BillingReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 18)]
        public IEnumerable<string> Delivery { get; set; } = Array.Empty<string>();

        [DataMember(Order = 25)]
        public IEnumerable<string> DeliveryTerms { get; set; } = Array.Empty<string>();

        [DataMember(Order = 12)]
        public IEnumerable<string> DespatchLineReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 2)]
        public IEnumerable<string> Note { get; set; } = Array.Empty<string>();

        [DataMember(Order = 11)]
        public IEnumerable<string> OrderLineReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 17)]
        public string OriginatorParty { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        public string PaymentPurposeCode { get; set; } = string.Empty;

        [DataMember(Order = 19)]
        public IEnumerable<string> PaymentTerms { get; set; } = Array.Empty<string>();

        [DataMember(Order = 24)]
        public decimal Price { get; set; }

        [DataMember(Order = 16)]
        public string PricingReference { get; set; } = string.Empty;

        [DataMember(Order = 13)]
        public IEnumerable<string> ReceiptLineReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 5)]
        public DateTimeOffset TaxPointDate { get; set; }

        [DataMember(Order = 21)]
        public IEnumerable<decimal> TaxTotal { get; set; } = Array.Empty<decimal>();

        [DataMember(Order = 1)]
        public string UUID { get; set; } = string.Empty;

        [DataMember(Order = 22)]
        public IEnumerable<decimal> WithholdingTaxTotal { get; set; } = Array.Empty<decimal>();
    */
    }
}