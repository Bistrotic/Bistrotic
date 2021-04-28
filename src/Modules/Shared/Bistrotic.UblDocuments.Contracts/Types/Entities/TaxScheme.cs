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
    public class TaxScheme
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Name { get; set; }

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? TaxTypeCode { get; set; }

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CurrencyCode { get; set; }

        [DataMember(Order = 4), ProtoMember(4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<Address> JurisdictionRegionAddress { get; set; } = new();
    }
}
