namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(Attachment), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(Attachment), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class Attachment
    {
        [XmlElement(nameof(EmbeddedDocumentBinaryObject), Namespace = UblNamespaces.CommonBasicComponents2, Order = 0)]
        public string EmbeddedDocumentBinaryObject { get; set; } = string.Empty;

        [XmlElement(nameof(ExternalReference), Order = 1)]
        public ExternalReference ExternalReference { get; set; } = new();
    }
}