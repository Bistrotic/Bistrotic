using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Bistrotic.UblDocuments.Types
{
    [Serializable]
    [DebuggerStepThrough]
    [XmlType("AdditionalDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot("AdditionalDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public class DocumentReference
    {
        [XmlElement("Attachment", Order = 13)]
        public Attachment Attachment;

        [XmlElement("CopyIndicator", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
        public string CopyIndicator;

        [XmlElement("DocumentStatusCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 11)]
        public string DocumentStatusCode;

        [XmlElement("DocumentType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 6)]
        public string DocumentType;

        [XmlElement("DocumentTypeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 5)]
        public string DocumentTypeCode;

        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
        public string ID;

        [XmlElement("IssueDate", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
        public DateType IssueDate;

        [XmlElement("IssuerParty", Order = 15)]
        public Party IssuerParty;

        [XmlElement("IssueTime", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
        public DateTimeOffset IssueTime;

        [XmlElement("LanguageID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 8)]
        public string LanguageID;

        [XmlElement("LocaleCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 9)]
        public string LocaleCode;

        [XmlElement("ResultOfVerification", Order = 16)]
        public string ResultOfVerification;

        [XmlElement("UUID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
        public string UUID;

        [XmlElement("ValidityPeriod", Order = 14)]
        public PeriodType ValidityPeriod;

        [XmlElement("VersionID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 10)]
        public string VersionID;

        private System.Collections.Generic.List<TextType> _documentDescription;
        private System.Collections.Generic.List<TextType> _xPath;

        [XmlElement("DocumentDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 12)]
        public TextType[] DocumentDescription
        {
            get
            {
                return _documentDescription?.ToArray();
            }
            set
            {
                _documentDescription = value == null ? null : new System.Collections.Generic.List<TextType>(value);
            }
        }

        [XmlElement("XPath", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 7)]
        public TextType[] XPath
        {
            get
            {
                return _xPath?.ToArray();
            }
            set
            {
                _xPath = value == null ? null : new System.Collections.Generic.List<TextType>(value);
            }
        }
    }
}