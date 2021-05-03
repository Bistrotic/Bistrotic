namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class PrepaidPayment
    {
        [DataMember(Order = 0), ProtoMember(1)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }

        [DataMember(Order = 5), ProtoMember(6)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? InstructionID { get; set; }

        [DataMember(Order = 1), ProtoMember(2)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PaidAmount { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 3, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? PaidDate
        {
            get => (PaidDateTime == null) ? null : new(PaidDateTime.Value);
            set => PaidDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 3, IsRequired = true), ProtoMember(4, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? PaidDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? PaidTime
        {
            get => (PaidDateTime == null) ? null : new(PaidDateTime.Value.ToLocalTime());
            set => PaidDateTime = Time.SetTime(PaidDateTime, value);
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 2, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? ReceivedDate
        {
            get => (ReceivedDateTime == null) ? null : new(ReceivedDateTime.Value);
            set => ReceivedDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 2, IsRequired = true), ProtoMember(3, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? ReceivedDateTime { get; set; }
    }
}