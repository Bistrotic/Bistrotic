namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Party
    {
        [DataMember(Order = 15)]
        public Party AgentParty { get; set; } = new();

        [DataMember(Order = 13)]
        public string Contact { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string EndpointID { get; set; } = string.Empty;

        [DataMember(Order = 18)]
        public string FinancialAccount { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string IndustryClassificationCode { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        public string Language { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string LogoReferenceID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string MarkAttentionIndicator { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string MarkCareIndicator { get; set; } = string.Empty;
        /*
                [DataMember(Order = 6)]
                public IEnumerable<PartyIdentification> PartyIdentification { get; set; } = Array.Empty<PartyIdentification>();

                [DataMember(Order = 12)]
                public IEnumerable<PartyLegalEntity> PartyLegalEntity { get; set; } = Array.Empty<PartyLegalEntity>();

                [DataMember(Order = 14)]
                public IEnumerable<CrewMemberPerson> Person { get; set; } = Array.Empty<CrewMemberPerson>();
        */
        [DataMember(Order = 7, IsRequired = true)]
        public PartyName PartyName { get; set; } = new();

        [DataMember(Order = 10)]
        public string PhysicalLocation { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        public string PostalAddress { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string WebsiteURI { get; set; } = string.Empty;
    }
}