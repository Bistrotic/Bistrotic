namespace Bistrotic.UblDocuments.Types.Entities
{
    using Bistrotic.UblDocuments.Types.ValueTypes;

    using ProtoBuf;

    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class PartyLegalEntity
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string RegistrationName { get; set; } = string.Empty;

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CompanyID { get; set; } = string.Empty;

        [DataMember(Order = 2, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? RegistrationDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 2, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? RegistrationDate
        {
            get => (RegistrationDateTime == null) ? null : new(RegistrationDateTime.Value);
            set => RegistrationDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? RegistrationExpirationDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 3, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? RegistrationExpirationDate
        {
            get => (RegistrationExpirationDateTime == null) ? null : new(RegistrationExpirationDateTime.Value);
            set => RegistrationExpirationDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 4), ProtoMember(4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CompanyLegalFormCode { get; set; } = string.Empty;

        [DataMember(Order = 5), ProtoMember(5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CompanyLegalForm { get; set; } = string.Empty;

        [DataMember(Order = 6), ProtoMember(6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string SoleProprietorshipIndicator { get; set; } = string.Empty;

        [DataMember(Order = 7), ProtoMember(7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CompanyLiquidationStatusCode { get; set; } = string.Empty;

        [DataMember(Order = 8), ProtoMember(8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal CorporateStockAmount { get; set; }

        [DataMember(Order = 9), ProtoMember(9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool FullyPaidSharesIndicator { get; set; }

        [DataMember(Order = 10), ProtoMember(10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Address RegistrationAddress { get; set; } = new();

        [DataMember(Order = 12), ProtoMember(12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party HeadOfficeParty { get; set; } = new();
    }
}
