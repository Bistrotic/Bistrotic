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
    public class Period
    {
        [DataMember(Order = 6), ProtoMember(7)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Description { get; set; }

        [DataMember(Order = 5), ProtoMember(6)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? DescriptionCode { get; set; }

        [DataMember(Order = 4), ProtoMember(5)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal? DurationMeasure { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 2, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? EndDate
        {
            get => (EndDateTime == null) ? null : new(EndDateTime.Value);
            set => EndDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 2, IsRequired = true), ProtoMember(3, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? EndDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? EndTime
        {
            get => (EndDateTime == null) ? null : new(EndDateTime.Value.ToLocalTime());
            set => Time.SetTime(EndDateTime, value);
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 0, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? StartDate
        {
            get => (StartDateTime == null) ? null : new(StartDateTime.Value);
            set => StartDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 0, IsRequired = true), ProtoMember(1, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? StartDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? StartTime
        {
            get => (StartDateTime == null) ? null : new(StartDateTime.Value.ToLocalTime());
            set => Time.SetTime(StartDateTime, value);
        }
    }
}