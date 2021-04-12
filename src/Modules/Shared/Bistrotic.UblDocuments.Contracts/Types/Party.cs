namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType("AdditionalInformationParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot("AdditionalInformationParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public class Party
    {
        [XmlElement("PartyIdentification", Order = 6)]
        public PartyIdentificationType[] PartyIdentification;

        [XmlElement("PartyLegalEntity", Order = 12)]
        public PartyLegalEntityType[] PartyLegalEntity;

        [XmlElement("PartyName", Order = 7)]
        public IEnumerable<string> PartyName;

        [XmlElement("PartyTaxScheme", Order = 11)]
        public PartyTaxSchemeType[] PartyTaxScheme;

        [XmlElement("Person", Order = 14)]
        public PersonType[] Person;

        [XmlElement("PowerOfAttorney", Order = 17)]
        public PowerOfAttorneyType[] PowerOfAttorney;

        [XmlElement("ServiceProviderParty", Order = 16)]
        public ServiceProviderPartyType[] ServiceProviderParty;

        [XmlElement("AgentParty", Order = 15)]
        public Party AgentParty { get; set; } = new();

        [XmlElement("Contact", Order = 13)]
        public string Contact { get; set; } = string.Empty;

        [XmlElement("EndpointID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public string EndpointID { get; set; } = string.Empty;

        [XmlElement("FinancialAccount", Order = 18)]
        public string FinancialAccount { get; set; } = string.Empty;

        [XmlElement("IndustryClassificationCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 5)]
        public string IndustryClassificationCode { get; set; } = string.Empty;

        [XmlElement("Language", Order = 8)]
        public string Language { get; set; } = string.Empty;

        [XmlElement("LogoReferenceID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public string LogoReferenceID { get; set; } = string.Empty;

        [XmlElement("MarkAttentionIndicator", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
        public string MarkAttentionIndicator { get; set; } = string.Empty;

        [XmlElement("MarkCareIndicator", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
        public string MarkCareIndicator { get; set; } = string.Empty;

        [XmlElement("PhysicalLocation", Order = 10)]
        public string PhysicalLocation { get; set; } = string.Empty;

        [XmlElement("PostalAddress", Order = 9)]
        public string PostalAddress { get; set; } = string.Empty;

        [XmlElement("WebsiteURI", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
        public string WebsiteURI { get; set; } = string.Empty;
    }
}