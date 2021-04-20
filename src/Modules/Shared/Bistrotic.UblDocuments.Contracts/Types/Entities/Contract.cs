namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Contract
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? IssueDate { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? IssueTime { get; set; }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? NominationDate { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Time? NominationTime { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ContractTypeCode { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ContractType { get; set; }

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<string> Note { get; set; } = new();

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? VersionID { get; set; }

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Description { get; set; }

        [DataMember(Order = 10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? ValidityPeriod { get; set; }

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ContractDocumentReference { get; set; } = new();

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? NominationPeriod { get; set; }

        [DataMember(Order = 13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Delivery? ContractualDelivery { get; set; }

    }
}