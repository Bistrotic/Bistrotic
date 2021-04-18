namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class TaxSubtotal
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal TaxableAmount { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        [XmlElement(Order = 1, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal TaxAmount { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal CalculationSequenceNumeric { get; set; }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal TransactionCurrencyTaxAmount { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal Percent { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal BaseUnitMeasure { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PerUnitAmount { get; set; }

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? TierRange { get; set; }

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal TierRatePercent { get; set; }

        [DataMember(Order = 9, IsRequired = true)]
        [XmlElement(Order = 9, IsNullable = false, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public TaxCategory TaxCategory { get; set; } = new();
    }
}
