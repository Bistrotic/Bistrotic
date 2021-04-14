namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class PartyLegalEntity
    {
        [DataMember(Order = 0)]
        public string RegistrationName { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string CompanyID { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public DateType RegistrationDate { get; set; } = new();

        [DataMember(Order = 3)]
        public DateType RegistrationExpirationDate { get; set; } = new();

        [DataMember(Order = 4)]
        public string CompanyLegalFormCode { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string CompanyLegalForm { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string SoleProprietorshipIndicator { get; set; } = string.Empty;

        [DataMember(Order = 7)]
        public string CompanyLiquidationStatusCode { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        public decimal CorporateStockAmount { get; set; }

        [DataMember(Order = 9)]
        public bool FullyPaidSharesIndicator { get; set; }

        [DataMember(Order = 10)]
        public Address RegistrationAddress { get; set; } = new();

        [DataMember(Order = 12)]
        public Party HeadOfficeParty { get; set; } = new();
    }
}
