﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using Bistrotic.UblDocuments.Types.ValueTypes;

    using ProtoBuf;

    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Delivery
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; } = string.Empty;


        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal Quantity { get; set; }

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MinimumQuantity { get; set; }

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MaximumQuantity { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? ActualDeliveryDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 4, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? ActualDeliveryDate
        {
            get => (ActualDeliveryDateTime == null) ? null : new(ActualDeliveryDateTime.Value);
            set => ActualDeliveryDateTime = (value == null) ? null : (DateTime)value;
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? ActualDeliveryTime
        {
            get => (ActualDeliveryDateTime == null) ? null : new(ActualDeliveryDateTime.Value.ToLocalTime());
            set => Time.SetTime(ActualDeliveryDateTime, value);
        }

        [DataMember(Order = 6, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? LatestDeliveryDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 6, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? LatestDeliveryDate
        {
            get => (LatestDeliveryDateTime == null) ? null : new(LatestDeliveryDateTime.Value);
            set => LatestDeliveryDateTime = (value == null) ? null : (DateTime)value;
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? LatestDeliveryTime
        {
            get => (LatestDeliveryDateTime == null) ? null : new(LatestDeliveryDateTime.Value.ToLocalTime());
            set => Time.SetTime(LatestDeliveryDateTime, value);
        }

        [DataMember(Order = 8), ProtoMember(8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ReleaseID { get; set; } = string.Empty;

        [DataMember(Order = 9), ProtoMember(9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? TrackingID { get; set; } = string.Empty;

        [DataMember(Order = 10), ProtoMember(10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Address? DeliveryAddress { get; set; }

        [DataMember(Order = 11), ProtoMember(11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Location? DeliveryLocation { get; set; }

        [DataMember(Order = 12), ProtoMember(12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Location? AlternativeDeliveryLocation { get; set; }

        [DataMember(Order = 13), ProtoMember(13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? RequestedDeliveryPeriod { get; set; }

        [DataMember(Order = 14), ProtoMember(14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? PromisedDeliveryPeriod { get; set; }

        [DataMember(Order = 15), ProtoMember(15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? EstimatedDeliveryPeriod { get; set; }

        [DataMember(Order = 16), ProtoMember(16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? CarrierParty { get; set; }

        [DataMember(Order = 17), ProtoMember(17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? DeliveryParty { get; set; }

        [DataMember(Order = 18), ProtoMember(18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? NotifyParty { get; set; }

        [DataMember(Order = 20), ProtoMember(20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DeliveryTerms? DeliveryTerms { get; set; }

    }
}