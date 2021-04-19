namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class BillingReferenceLine
    {
        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement(Order = 0, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal Amount { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<AllowanceCharge> AllowanceCharge { get; set; } = new();

    }
}