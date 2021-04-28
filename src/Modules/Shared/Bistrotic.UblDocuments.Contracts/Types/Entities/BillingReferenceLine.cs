namespace Bistrotic.UblDocuments.Types.Entities
{
    using ProtoBuf;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class BillingReferenceLine
    {
        [Key]
        [XmlIgnore]
        [IgnoreDataMember]
        public int BillingReferenceLineId { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public int BillingReferenceId { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public BillingReference BillingReference { get; set; } = new();

        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement(Order = 0, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal Amount { get; set; }

        [NotMapped]
        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<AllowanceCharge> AllowanceCharge { get; set; } = new();

    }
}