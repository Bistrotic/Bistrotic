namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(PartyLegalEntity), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(PartyLegalEntity), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class PartyLegalEntity
    {
        [XmlElement(nameof(RegistrationName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string RegistrationName { get; set; } = string.Empty;

        [XmlElement(nameof(CompanyID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string CompanyID { get; set; } = string.Empty;

        [XmlElement(nameof(RegistrationDate), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public DateType RegistrationDate { get; set; } = new();

        [XmlElement(nameof(RegistrationExpirationDate), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public DateType RegistrationExpirationDate { get; set; } = new();

        [XmlElement(nameof(CompanyLegalFormCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public string CompanyLegalFormCode { get; set; } = string.Empty;

        [XmlElement(nameof(CompanyLegalForm), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string CompanyLegalForm { get; set; } = string.Empty;

        [XmlElement(nameof(SoleProprietorshipIndicator), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string SoleProprietorshipIndicator { get; set; } = string.Empty;

        [XmlElement(nameof(CompanyLiquidationStatusCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 7)]
        public string CompanyLiquidationStatusCode { get; set; } = string.Empty;

        [XmlElement(nameof(CorporateStockAmount), Namespace = UblNamespaces.CommonBasicComponents2, Order = 8)]
        public decimal CorporateStockAmount { get; set; }

        [XmlElement(nameof(FullyPaidSharesIndicator), Namespace = UblNamespaces.CommonBasicComponents2, Order = 9)]
        public bool FullyPaidSharesIndicator { get; set; }

        [XmlElement(nameof(RegistrationAddress), Order = 10)]
        public Address RegistrationAddress { get; set; } = new();

        [XmlElement(nameof(HeadOfficeParty), Order = 12)]
        public Party HeadOfficeParty { get; set; } = new();
    }
}
