﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class PartyIdentification
    {
        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;
    }
}