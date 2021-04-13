namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(Country), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(Country), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class Country
    {
        [XmlElement(
            "IdentificationCode",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 0)]
        public string IdentificationCode { get; set; } = string.Empty;

        [XmlElement(
            "Name",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 1)]
        public string Name { get; set; } = string.Empty;
    }
}