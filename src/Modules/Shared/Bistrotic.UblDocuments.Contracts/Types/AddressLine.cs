namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(
        "AddressLine",
        Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(
        "AddressLine",
        Namespace = UblNamespaces.CommonAggregateComponents2,
        IsNullable = false)]
    public class AddressLine
    {
        [XmlElement(
            "Line",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 0)]
        public string Line { get; set; } = string.Empty;
    }
}