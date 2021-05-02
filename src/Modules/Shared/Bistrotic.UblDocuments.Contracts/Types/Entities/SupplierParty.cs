﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class SupplierParty
    {
        [DataMember(Order = 5), ProtoMember(6)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Contact? AccountingContact { get; set; }

        [DataMember(Order = 1), ProtoMember(2)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> AdditionalAccountID { get; set; } = new();

        [DataMember(Order = 0), ProtoMember(1)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CustomerAssignedAccountID { get; set; }

        [DataMember(Order = 2), ProtoMember(3)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? DataSendingCapability { get; set; }

        [DataMember(Order = 4), ProtoMember(5)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Contact? DespatchContact { get; set; }

        [DataMember(Order = 3, IsRequired = true), ProtoMember(4, IsRequired = true)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? Party { get; set; } = new();

        [DataMember(Order = 6), ProtoMember(7)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Contact? SellerContact { get; set; }
    }
}