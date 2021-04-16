namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Name = nameof(Attachment), Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Attachment
    {
        [DataMember(Order = 0)]
        public string EmbeddedDocumentBinaryObject { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public ExternalReference ExternalReference { get; set; } = new();
    }
}