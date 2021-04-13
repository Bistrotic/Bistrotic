namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(
        "PartyIdentification",
        Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(
        "PartyIdentification",
        Namespace = UblNamespaces.CommonAggregateComponents2,
        IsNullable = false)]
    public class PartyIdentification
    {
        [XmlElement(
            "ID",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 0)]
        public string ID { get; set; } = string.Empty;
    }
}