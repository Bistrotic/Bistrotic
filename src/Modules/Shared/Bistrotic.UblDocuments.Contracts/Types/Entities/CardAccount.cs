namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class CardAccount
    {
        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement(Order = 0, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string PrimaryAccountNumberID { get; set; } = string.Empty;

        [DataMember(Order = 1, IsRequired = true)]
        [XmlElement(Order = 1, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string NetworkID { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Code? CardTypeCode { get; set; } = new();

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? ValidityStartDate { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? ExpiracyDate { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? IssuerID { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? IssuerNumberID { get; set; }

        [DataMember(Order = 7, IsRequired = true)]
        [XmlElement(Order = 7, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CV2ID { get; set; }

        [DataMember(Order = 8, IsRequired = true)]
        [XmlElement(Order = 8, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? CardChipCode { get; set; }

        [DataMember(Order = 9, IsRequired = true)]
        [XmlElement(Order = 9, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ChipApplicationID { get; set; }

        [DataMember(Order = 10, IsRequired = true)]
        [XmlElement(Order = 10, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? HolderName { get; set; }

    }
}
