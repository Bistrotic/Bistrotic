namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable]
    [DebuggerStepThrough]
    [XmlType(nameof(AccountingContact), Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlRoot(nameof(AccountingContact), Namespace = UblNamespaces.CommonAggregateComponents2, IsNullable = false)]
    public class AccountingContact
    {
        [XmlElement(
            "ElectronicMail",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 4)]
        public string ElectronicMail { get; set; } = string.Empty;

        [XmlElement(
            "ID",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 0)]
        public string ID { get; set; } = string.Empty;

        [XmlElement(
            "Name",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 1)]
        public string Name { get; set; } = string.Empty;

        [XmlElement(
            "Note",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 5)]
        public string Note { get; set; } = string.Empty;

        [XmlElement(
            "OtherCommunication",
            Order = 6)]
        public IEnumerable<Communication> OtherCommunication { get; set; } = Array.Empty<Communication>();

        [XmlElement(
            "Telefax",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 3)]
        public string Telefax { get; set; } = string.Empty;

        [XmlElement(
            "Telephone",
            Namespace = UblNamespaces.CommonBasicComponents2,
            Order = 2)]
        public string Telephone { get; set; } = string.Empty;
    }
}