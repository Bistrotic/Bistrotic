namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(Communication), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(Communication), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class Communication
    {
        [XmlElement(
            "Channel",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 1)]
        public string Channel { get; set; } = string.Empty;

        [XmlElement(
            "ChannelCode",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 0)]
        public string ChannelCode { get; set; } = string.Empty;

        [XmlElement(
            "Value",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 2)]
        public string Value { get; set; } = string.Empty;
    }
}