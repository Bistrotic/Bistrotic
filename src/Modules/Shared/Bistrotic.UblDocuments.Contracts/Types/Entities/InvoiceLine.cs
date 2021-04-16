namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class InvoiceLine
    {
        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AccountingCost { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AccountingCostCode { get; set; } = string.Empty;

        [DataMember(Order = 15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string[] DocumentReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string FreeOfChargeIndicator { get; set; } = string.Empty;

        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal InvoicedQuantity { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal LineExtensionAmount { get; set; }

        [DataMember(Order = 10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period InvoicePeriod { get; set; } = new();

        [DataMember(Order = 23, IsRequired = true)]
        [XmlElement(Order = 23, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Item Item { get; set; } = new();
        /*
        [DataMember(Order = 20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> AllowanceCharge { get; set; } = Array.Empty<string>();

        [DataMember(Order = 14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> BillingReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> Delivery { get; set; } = Array.Empty<string>();

        [DataMember(Order = 25)]
        [XmlElement(Order = 25, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> DeliveryTerms { get; set; } = Array.Empty<string>();

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> DespatchLineReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> Note { get; set; } = Array.Empty<string>();

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> OrderLineReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string OriginatorParty { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string PaymentPurposeCode { get; set; } = string.Empty;

        [DataMember(Order = 19)]
        [XmlElement(Order = 19, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> PaymentTerms { get; set; } = Array.Empty<string>();

        [DataMember(Order = 24)]
        [XmlElement(Order = 24, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal Price { get; set; }

        [DataMember(Order = 16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string PricingReference { get; set; } = string.Empty;

        [DataMember(Order = 13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> ReceiptLineReference { get; set; } = Array.Empty<string>();

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DateTimeOffset TaxPointDate { get; set; }

        [DataMember(Order = 21)]
        [XmlElement(Order = 21, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<decimal> TaxTotal { get; set; } = Array.Empty<decimal>();

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string UUID { get; set; } = string.Empty;

        [DataMember(Order = 22)]
        [XmlElement(Order = 22, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<decimal> WithholdingTaxTotal { get; set; } = Array.Empty<decimal>();
    */
    }
}