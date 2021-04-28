namespace Bistrotic.UblDocuments.Types.Entities
{
    using ProtoBuf;

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class PaymentMandate
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; }

        [DataMember(Order = 1), ProtoMember(1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? MandateTypeCode { get; set; }

        [DataMember(Order = 2), ProtoMember(2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MaximumPaymentInstructionsNumeric { get; set; }

        [DataMember(Order = 3), ProtoMember(3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MaximumPaidAmount { get; set; }

        [DataMember(Order = 4), ProtoMember(4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? SignatureID { get; set; }

        [DataMember(Order = 5), ProtoMember(5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party? PayerParty { get; set; }

        [DataMember(Order = 6), ProtoMember(6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public FinancialAccount? PayerFinancialAccount { get; set; }

        [DataMember(Order = 7), ProtoMember(7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? ValidityPeriod { get; set; }

        [DataMember(Order = 8), ProtoMember(8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Period? PaymentReversalPeriod { get; set; }

        [DataMember(Order = 10, IsRequired = true)]
        [XmlElement(Order = 10, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<Clause> Clause { get; set; } = new();

    }
}
