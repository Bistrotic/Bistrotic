namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(nameof(OrderReference) + "Type", Namespace = UblNamespaces.CommonAggregateComponents2)]
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
        [XmlElement(Order = 4, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DateType? IssueDate { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement(Order = 5, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public TimeType? IssueTime { get; set; }

        [DataMember(Order = 6, IsRequired = true)]
        [XmlElement(Order = 6, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CustomerReference { get; set; }

        [DataMember(Order = 7, IsRequired = true)]
        [XmlElement(Order = 7, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public OrderTypeCode? OrderTypeCode { get; set; }

        [DataMember(Order = 8, IsRequired = true)]
        [XmlElement(Order = 8, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? DocumentReference { get; set; }

    }
}
