﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Price
    {
        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PriceAmount { get; set; }

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal BaseQuantity { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> PriceChangeReason { get; set; } = new();

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? PriceTypeCode { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal? PriceType { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal OrderableUnitFactorRate { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<Period> ValidityPeriod { get; set; } = new();

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public PriceList? PriceList { get; set; }

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<AllowanceCharge> AllowanceCharge { get; set; } = new();

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public ExchangeRate? PricingExchangeRate { get; set; }

    }
}