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
    public class TradeFinancing
    {
        [DataMember(Order = 6, IsRequired = true), ProtoMember(7, IsRequired = true)]
        [XmlElement(Order = 6, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<Clause> Clause { get; set; } = new();

        [DataMember(Order = 2), ProtoMember(3)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DocumentReference? ContractDocumentReference { get; set; }

        [DataMember(Order = 3), ProtoMember(4)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> DocumentReference { get; set; } = new();

        [DataMember(Order = 5), ProtoMember(6)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public FinancialAccount? FinancingFinancialAccount { get; set; }

        [DataMember(Order = 1), ProtoMember(2)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? FinancingInstrumentTypeCode { get; set; }

        [DataMember(Order = 4), ProtoMember(5)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? FinancingParty { get; set; }

        [DataMember(Order = 0), ProtoMember(1)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }
    }
}