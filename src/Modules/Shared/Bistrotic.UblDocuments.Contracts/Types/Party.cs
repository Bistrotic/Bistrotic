namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(
        "AdditionalInformationParty",
        Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(
        "AdditionalInformationParty",
        Namespace = UblNamespaces.CommonAggregateComponents2,
        IsNullable = false)]
    public class Party
    {
        [XmlElement(nameof(AgentParty), Order = 15)]
        public Party AgentParty { get; set; } = new();

        [XmlElement(nameof(Contact), Order = 13)]
        public string Contact { get; set; } = string.Empty;

        [XmlElement(nameof(EndpointID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public string EndpointID { get; set; } = string.Empty;

        [XmlElement(nameof(FinancialAccount), Order = 18)]
        public string FinancialAccount { get; set; } = string.Empty;

        [XmlElement(nameof(IndustryClassificationCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string IndustryClassificationCode { get; set; } = string.Empty;

        [XmlElement(nameof(Language), Order = 8)]
        public string Language { get; set; } = string.Empty;

        [XmlElement(nameof(LogoReferenceID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public string LogoReferenceID { get; set; } = string.Empty;

        [XmlElement(nameof(MarkAttentionIndicator), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string MarkAttentionIndicator { get; set; } = string.Empty;

        [XmlElement(nameof(MarkCareIndicator), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string MarkCareIndicator { get; set; } = string.Empty;

        [XmlElement(nameof(PartyIdentification), Order = 6)]
        public IEnumerable<PartyIdentification> PartyIdentification { get; set; } = Array.Empty<PartyIdentification>();

        [XmlElement(nameof(PartyLegalEntity), Order = 12)]
        public IEnumerable<PartyLegalEntity> PartyLegalEntity { get; set; } = Array.Empty<PartyLegalEntity>();

        [XmlElement(nameof(PartyName), Order = 7)]
        public IEnumerable<string> PartyName { get; set; } = Array.Empty<string>();

        [XmlElement(nameof(Person), Order = 14)]
        public IEnumerable<CrewMemberPerson> Person { get; set; } = Array.Empty<CrewMemberPerson>();

        [XmlElement(nameof(PhysicalLocation), Order = 10)]
        public string PhysicalLocation { get; set; } = string.Empty;

        [XmlElement(nameof(PostalAddress), Order = 9)]
        public string PostalAddress { get; set; } = string.Empty;


        [XmlElement(nameof(WebsiteURI), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string WebsiteURI { get; set; } = string.Empty;
    }
}