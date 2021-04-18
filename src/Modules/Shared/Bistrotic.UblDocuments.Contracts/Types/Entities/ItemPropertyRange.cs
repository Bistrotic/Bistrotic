namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class ItemPropertyRange
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MinimumValue { get; set; }

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal MaximumValue { get; set; }
    }
}