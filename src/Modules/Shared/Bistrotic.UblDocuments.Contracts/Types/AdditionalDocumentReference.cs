using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Bistrotic.UblDocuments.Types
{
    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(AdditionalDocumentReference), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(AdditionalDocumentReference), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class AdditionalDocumentReference
    {
        [XmlElement(nameof(DocumentDescription), Namespace = UblNamespaces.CommonBasicComponents2, Order = 12)]
        public string DocumentDescription { get; set; } = string.Empty;

        [XmlElement(nameof(XPath), Namespace = UblNamespaces.CommonBasicComponents2, Order = 7)]
        public string XPath { get; set; } = string.Empty;

        [XmlElement(nameof(Attachment), Order = 13)]
        public Attachment Attachment { get; set; } = new();

        [XmlElement(nameof(CopyIndicator), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string CopyIndicator { get; set; } = string.Empty;

        [XmlElement(nameof(DocumentStatusCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 11)]
        public string DocumentStatusCode { get; set; } = string.Empty;

        [XmlElement(nameof(DocumentType), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string DocumentType { get; set; } = string.Empty;

        [XmlElement(nameof(DocumentTypeCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string DocumentTypeCode { get; set; } = string.Empty;

        [XmlElement(nameof(ID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(nameof(IssueDate), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public DateTimeOffset IssueDate { get; set; }

        [XmlElement(nameof(IssuerParty), Order = 15)]
        public Party IssuerParty { get; set; } = new();

        [XmlElement(nameof(IssueTime), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public DateTimeOffset IssueTime { get; set; }

        [XmlElement(nameof(LanguageID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 8)]
        public string LanguageID { get; set; } = string.Empty;

        [XmlElement(nameof(LocaleCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 9)]
        public string LocaleCode { get; set; } = string.Empty;

        [XmlElement(nameof(ResultOfVerification), Order = 16)]
        public string ResultOfVerification { get; set; } = string.Empty;

        [XmlElement(nameof(UUID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string UUID { get; set; } = string.Empty;

        [XmlElement(nameof(ValidityPeriod), Order = 14)]
        public Period ValidityPeriod { get; set; } = new();

        [XmlElement(nameof(VersionID), Namespace = UblNamespaces.CommonBasicComponents2, Order = 10)]
        public string VersionID { get; set; } = string.Empty;
    }
}