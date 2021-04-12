namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType("Communication", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [XmlRoot("Communication", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public class Communication
    {
        [XmlElement(
            "Channel",
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 1)]
        public string Channel { get; set; } = string.Empty;

        [XmlElement(
            "ChannelCode",
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 0)]
        public string ChannelCode { get; set; } = string.Empty;

        [XmlElement(
            "Value",
            Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            Order = 2)]
        public string Value { get; set; } = string.Empty;
    }
}