namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class WorkPhaseReference
    {
        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? EndDate
        {
            get => (EndDateTime == null) ? null : new(EndDateTime.Value);
            set => EndDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 4), ProtoMember(5)]
        [XmlIgnore]
        public DateTimeOffset? EndDateTime { get; set; }

        [DataMember(Order = 0, IsRequired = true), ProtoMember(1, IsRequired = true)]
        [XmlElement(Order = 0, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }

        [DataMember(Order = 2), ProtoMember(3)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal? ProgressPercent { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? StartDate
        {
            get => (StartDateTime == null) ? null : new(StartDateTime.Value);
            set => StartDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 3), ProtoMember(4)]
        [XmlIgnore]
        public DateTimeOffset? StartDateTime { get; set; }

        [DataMember(Order = 5, IsRequired = true), ProtoMember(6, IsRequired = true)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference>? WorkOrderDocumentReference { get; set; } = new();

        [DataMember(Order = 1), ProtoMember(2)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? WorkPhaseCode { get; set; }
    }
}