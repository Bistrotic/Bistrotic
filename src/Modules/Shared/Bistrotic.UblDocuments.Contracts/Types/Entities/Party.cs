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
    public class Party
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool MarkCareIndicator { get; set; }

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool MarkAttentionIndicator { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string WebsiteURI { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string LogoReferenceID { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string EndpointID { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? IndustryClassificationCode { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<PartyIdentification> PartyIdentification { get; set; } = new();

        [DataMember(Order = 7, IsRequired = true)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public PartyName PartyName { get; set; } = new();

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Language { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Address? PostalAddress { get; set; }

        [DataMember(Order = 10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string PhysicalLocation { get; set; } = string.Empty;

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<PartyTaxScheme> PartyTaxScheme { get; set; } = new();

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<PartyLegalEntity> PartyLegalEntity { get; set; } = new();

        [DataMember(Order = 13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<Contact> Contact { get; set; } = new();

        [DataMember(Order = 14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<CrewMemberPerson> Person { get; set; } = new();

        [DataMember(Order = 15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string AgentParty { get; set; } = string.Empty;

        [DataMember(Order = 18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public FinancialAccount? FinancialAccount { get; set; }
    }
}