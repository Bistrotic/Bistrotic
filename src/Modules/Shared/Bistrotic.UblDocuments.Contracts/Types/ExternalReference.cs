namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(ExternalReference), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(ExternalReference), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class ExternalReference
    {
        [XmlElement(nameof(CharacterSetCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 8)]
        public string CharacterSetCode { get; set; } = string.Empty;

        [XmlElement(nameof(Description), Namespace = UblNamespaces.CommonBasicComponents2, Order = 10)]
        public string Description { get; set; } = string.Empty;

        [XmlElement(nameof(DocumentHash), Namespace = UblNamespaces.CommonBasicComponents2, Order = 1)]
        public string DocumentHash { get; set; } = string.Empty;

        [XmlElement(nameof(EncodingCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 7)]
        public string EncodingCode { get; set; } = string.Empty;

        [XmlElement(nameof(ExpiryDate), Namespace = UblNamespaces.CommonBasicComponents2, Order = 3)]
        public DateTimeOffset ExpiryDate { get; set; }

        [XmlElement(nameof(ExpiryTime), Namespace = UblNamespaces.CommonBasicComponents2, Order = 4)]
        public DateTime ExpiryTime { get; set; }

        [XmlElement(nameof(FileName), Namespace = UblNamespaces.CommonBasicComponents2, Order = 9)]
        public string FileName { get; set; } = string.Empty;

        [XmlElement(nameof(FormatCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 6)]
        public string FormatCode { get; set; } = string.Empty;

        [XmlElement(nameof(HashAlgorithmMethod), Namespace = UblNamespaces.CommonBasicComponents2, Order = 2)]
        public string HashAlgorithmMethod { get; set; } = string.Empty;

        [XmlElement(nameof(MimeCode), Namespace = UblNamespaces.CommonBasicComponents2, Order = 5)]
        public string MimeCode { get; set; } = string.Empty;

        [XmlElement(nameof(URI), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string URI { get; set; } = string.Empty;
    }
}