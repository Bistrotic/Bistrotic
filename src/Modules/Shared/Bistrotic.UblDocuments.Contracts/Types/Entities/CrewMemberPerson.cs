namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class CrewMemberPerson
    {
        [DataMember(Order = 10)]
        public DateTimeOffset BirthDate { get; set; }

        [DataMember(Order = 11)]
        public string BirthplaceName { get; set; } = string.Empty;

        [DataMember(Order = 13)]
        public AccountingContact Contact { get; set; } = new();

        [DataMember(Order = 2)]
        public string FamilyName { get; set; } = string.Empty;

        [DataMember(Order = 14)]
        public FinancialAccount FinancialAccount { get; set; } = new();

        [DataMember(Order = 1)]
        public string FirstName { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        public string GenderCode { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 15)]
        public IEnumerable<AdditionalDocumentReference> IdentityDocumentReference { get; set; } = Array.Empty<AdditionalDocumentReference>();

        [DataMember(Order = 7)]
        public string JobTitle { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string MiddleName { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string NameSuffix { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        public string NationalityID { get; set; } = string.Empty;

        [DataMember(Order = 12)]
        public string OrganizationDepartment { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string OtherName { get; set; } = string.Empty;

        [DataMember(Order = 16)]
        public Address ResidenceAddress { get; set; } = new();

        [DataMember(Order = 3)]
        public string Title { get; set; } = string.Empty;
    }
}