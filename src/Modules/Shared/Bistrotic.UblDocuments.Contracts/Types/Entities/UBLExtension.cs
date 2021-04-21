﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonExtensionComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonExtensionComponents2)]
    public class UBLExtension
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string Name { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionAgencyID { get; set; }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionAgencyName { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionVersionID { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionAgencyURI { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionURI { get; set; } = string.Empty;

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionReasonCode { get; set; } = string.Empty;

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public string? ExtensionReason { get; set; } = string.Empty;

        [NotMapped]
        [DataMember(Order = 9, IsRequired = true)]
        [XmlAnyElement(Order = 9, Namespace = UblNamespaces.CommonExtensionComponents2)]
        public object[] ExtensionContent { get; set; } = Array.Empty<object>();
    }
}