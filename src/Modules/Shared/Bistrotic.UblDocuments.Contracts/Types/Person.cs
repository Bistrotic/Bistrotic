namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType("CrewMemberPerson", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot("CrewMemberPerson", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public class Person
    {
        [XmlElementAttribute("BirthDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 10)]
        public DateTimeOffset BirthDate;

        [XmlElementAttribute("ResidenceAddress", Order = 16)]
        public AddressType ResidenceAddress;

        [XmlElementAttribute("BirthplaceName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 11)]
        public string BirthplaceName { get; set; } = string.Empty;

        [XmlElementAttribute("Contact", Order = 13)]
        public Contact Contact { get; set; } = new();

        [XmlElementAttribute("FamilyName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
        public string FamilyName { get; set; } = string.Empty;

        [XmlElementAttribute("FinancialAccount", Order = 14)]
        public FinancialAccount FinancialAccount { get; set; } = new();

        [XmlElementAttribute("FirstName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
        public string FirstName { get; set; } = string.Empty;

        [XmlElementAttribute("GenderCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 9)]
        public string GenderCode { get; set; } = string.Empty;

        [XmlElementAttribute("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElementAttribute("IdentityDocumentReference", Order = 15)]
        public IEnumerable<DocumentReference> IdentityDocumentReference { get; set; } = Array.Empty<DocumentReference>();

        [XmlElementAttribute("JobTitle", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 7)]
        public string JobTitle { get; set; } = string.Empty;

        [XmlElementAttribute("MiddleName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public string MiddleName { get; set; } = string.Empty;

        [XmlElementAttribute("NameSuffix", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 6)]
        public string NameSuffix { get; set; } = string.Empty;

        [XmlElementAttribute("NationalityID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 8)]
        public string NationalityID { get; set; } = string.Empty;

        [XmlElementAttribute("OrganizationDepartment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 12)]
        public string OrganizationDepartment { get; set; } = string.Empty;

        [XmlElementAttribute("OtherName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 5)]
        public string OtherName { get; set; } = string.Empty;

        [XmlElementAttribute("Title", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public string Title { get; set; } = string.Empty;
    }
}