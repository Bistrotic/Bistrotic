using System;
using System.Runtime.Serialization;

namespace Bistrotic.UblDocuments.Types
{
    [Serializable]
    [DataContract(Name = nameof(AdditionalDocumentReference), Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class AdditionalDocumentReference
    {
        [DataMember(Order = 12)]
        public string DocumentDescription { get; set; } = string.Empty;

        [DataMember(Order = 7)]
        public string XPath { get; set; } = string.Empty;

        [DataMember(Order = 13)]
        public Attachment Attachment { get; set; } = new();

        [DataMember(Order = 1)]
        public string CopyIndicator { get; set; } = string.Empty;

        [DataMember(Order = 11)]
        public string DocumentStatusCode { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string DocumentType { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string DocumentTypeCode { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public DateTimeOffset IssueDate { get; set; }

        [DataMember(Order = 15)]
        public Party IssuerParty { get; set; } = new();

        [DataMember(Order = 4)]
        public DateTimeOffset IssueTime { get; set; }

        [DataMember(Order = 8)]
        public string LanguageID { get; set; } = string.Empty;

        [DataMember(Order = 9)]
        public string LocaleCode { get; set; } = string.Empty;

        [DataMember(Order = 16)]
        public string ResultOfVerification { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string UUID { get; set; } = string.Empty;

        [DataMember(Order = 14)]
        public Period ValidityPeriod { get; set; } = new();

        [DataMember(Order = 10)]
        public string VersionID { get; set; } = string.Empty;
    }
}