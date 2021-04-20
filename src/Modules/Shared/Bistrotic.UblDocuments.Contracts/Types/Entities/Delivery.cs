namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Delivery
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; } = string.Empty;


        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal Quantity { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MinimumQuantity { get; set; }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MaximumQuantity { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? ActualDeliveryDate { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? ActualDeliveryTime { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? LatestDeliveryDate { get; set; }

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? LatestDeliveryTime { get; set; }

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ReleaseID { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? TrackingID { get; set; } = string.Empty;

        [DataMember(Order = 10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Address? DeliveryAddress { get; set; }

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Location? DeliveryLocation { get; set; }

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Location? AlternativeDeliveryLocation { get; set; }

        [DataMember(Order = 13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? RequestedDeliveryPeriod { get; set; }

        [DataMember(Order = 14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? PromisedDeliveryPeriod { get; set; }

        [DataMember(Order = 15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? EstimatedDeliveryPeriod { get; set; }

        [DataMember(Order = 16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? CarrierParty { get; set; }

        [DataMember(Order = 17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? DeliveryParty { get; set; }

        [DataMember(Order = 18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? NotifyParty { get; set; }

        [DataMember(Order = 20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DeliveryTerms? DeliveryTerms { get; set; }

    }
}