namespace Bistrotic.UblDocuments.Types.Entities
{
    using Bistrotic.UblDocuments.Types.ValueTypes;

    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class OrderReference
    {
        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement(Order = 0, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1, IsRequired = true)]
        [XmlElement(Order = 1, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? SalesOrderID { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement(Order = 2, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool CopyIndicator { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement(Order = 3, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? UUID { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? IssueDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 4, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? IssueDate
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value);
            set => IssueDateTime = (value == null) ? null : (DateTime)value;
        }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? IssueTime
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value.ToLocalTime());
            set => Time.SetTime(IssueDateTime, value);
        }

        [DataMember(Order = 6, IsRequired = true)]
        [XmlElement(Order = 6, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CustomerReference { get; set; }

        [DataMember(Order = 7, IsRequired = true)]
        [XmlElement(Order = 7, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? OrderTypeCode { get; set; }

        [DataMember(Order = 8, IsRequired = true)]
        [XmlElement(Order = 8, IsNullable = false, Namespace = UblNamespaces.CommonAggregateComponents2)]
        [ForeignKey(nameof(Entities.DocumentReference.Key))]
        public DocumentReference? DocumentReference { get; set; }

    }
}
