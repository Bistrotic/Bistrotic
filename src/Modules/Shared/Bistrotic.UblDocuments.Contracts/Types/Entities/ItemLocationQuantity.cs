﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using ProtoBuf;

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class ItemLocationQuantity
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal LeadTimeMeasure { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MinimumQuantity { get; set; }

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MaximumQuantity { get; set; }

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool HazardousRiskIndicator { get; set; }

        [DataMember(Order = 5), ProtoMember(5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Price? Price { get; set; }

        [DataMember(Order = 8), ProtoMember(8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<TaxCategory> ApplicableTaxCategory { get; set; } = new();

        [DataMember(Order = 10), ProtoMember(10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<AllowanceCharge> AllowanceCharge { get; set; } = new();

    }
}