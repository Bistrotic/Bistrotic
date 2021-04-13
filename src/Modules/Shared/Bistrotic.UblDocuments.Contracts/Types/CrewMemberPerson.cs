namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(CrewMemberPerson), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(CrewMemberPerson), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class CrewMemberPerson
    {
        [XmlElement(nameof(BirthDate), Namespace = UblNamespaces.CommonBasicComponents2, Order = 10)]
        public DateTimeOffset BirthDate { get; set; }

        [XmlElement(nameof(BirthplaceName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 11)]
        public string BirthplaceName { get; set; } = string.Empty;

        [XmlElement(nameof(Contact), Order = 13)]
        public AccountingContact Contact { get; set; } = new();

        [XmlElement(nameof(FamilyName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string FamilyName { get; set; } = string.Empty;

        [XmlElement(nameof(FinancialAccount), Order = 14)]
        public FinancialAccount FinancialAccount { get; set; } = new();

        [XmlElement(nameof(FirstName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string FirstName { get; set; } = string.Empty;

        [XmlElement(nameof(GenderCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 9)]
        public string GenderCode { get; set; } = string.Empty;

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(IdentityDocumentReference), Order = 15)]
        public IEnumerable<AdditionalDocumentReference> IdentityDocumentReference { get; set; } = Array.Empty<AdditionalDocumentReference>();

        [XmlElement(nameof(JobTitle), Namespace = UblNamespaces.CommonBasicComponents2, Order = 7)]
        public string JobTitle { get; set; } = string.Empty;

        [XmlElement(nameof(MiddleName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public string MiddleName { get; set; } = string.Empty;

        [XmlElement(nameof(NameSuffix), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string NameSuffix { get; set; } = string.Empty;

        [XmlElement(nameof(NationalityID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 8)]
        public string NationalityID { get; set; } = string.Empty;

        [XmlElement(nameof(OrganizationDepartment), Namespace = UblNamespaces.CommonBasicComponents2, Order = 12)]
        public string OrganizationDepartment { get; set; } = string.Empty;

        [XmlElement(nameof(OtherName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string OtherName { get; set; } = string.Empty;

        [XmlElement(nameof(ResidenceAddress), Order = 16)]
        public Address ResidenceAddress { get; set; } = new();

        [XmlElement(nameof(Title), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public string Title { get; set; } = string.Empty;
    }
}