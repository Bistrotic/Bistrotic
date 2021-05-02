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
    public class Contract
    {
        [DataMember(Order = 11), ProtoMember(12)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ContractDocumentReference { get; set; } = new();

        [DataMember(Order = 6), ProtoMember(7)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ContractType { get; set; }

        [DataMember(Order = 5), ProtoMember(6)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ContractTypeCode { get; set; }

        [DataMember(Order = 13), ProtoMember(14)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Delivery? ContractualDelivery { get; set; }

        [DataMember(Order = 9), ProtoMember(10)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Description { get; set; }

        [DataMember(Order = 0), ProtoMember(1)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 1, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? IssueDate
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value);
            set => IssueDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 1, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? IssueDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? IssueTime
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value.ToLocalTime());
            set => Time.SetTime(IssueDateTime, value);
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 3, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? NominationDate
        {
            get => (NominationDateTime == null) ? null : new(NominationDateTime.Value);
            set => NominationDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 3, IsRequired = true), ProtoMember(4, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? NominationDateTime { get; set; }

        [DataMember(Order = 12), ProtoMember(13)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? NominationPeriod { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? NominationTime
        {
            get => (NominationDateTime == null) ? null : new(NominationDateTime.Value.ToLocalTime());
            set => Time.SetTime(NominationDateTime, value);
        }

        [DataMember(Order = 7), ProtoMember(8)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<string> Note { get; set; } = new();

        [DataMember(Order = 10), ProtoMember(11)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? ValidityPeriod { get; set; }

        [DataMember(Order = 8), ProtoMember(9)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? VersionID { get; set; }
    }
}