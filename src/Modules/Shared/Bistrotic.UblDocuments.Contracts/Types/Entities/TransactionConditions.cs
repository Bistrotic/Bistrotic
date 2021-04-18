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
    public class TransactionConditions
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ActionCode { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Description { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> DocumentReference { get; set; } = new();
    }
}