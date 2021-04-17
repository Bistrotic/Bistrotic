namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class SupplierParty
    {
        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AccountingContact { get; set; } = string.Empty;

        /*
        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public IEnumerable<string> AdditionalAccountID { get; set; } = Array.Empty<string>();
        */
        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string CustomerAssignedAccountID { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string DataSendingCapability { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string DespatchContact { get; set; } = string.Empty;

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Party Party { get; set; } = new();

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string SellerContact { get; set; } = string.Empty;
    }
}