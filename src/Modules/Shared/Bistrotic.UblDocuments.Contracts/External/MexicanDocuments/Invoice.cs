﻿namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("FactDocMX", Namespace = MxNamespaces.Fx)]
    [XmlRoot("FactDocMX", Namespace = MxNamespaces.Fx)]
    public class Invoice
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = MxNamespaces.Fx)]
        public int Version { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("Identificacion", Order = 1, Namespace = MxNamespaces.Fx)]
        public Identification? Identification { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("Procesamiento", Order = 2, Namespace = MxNamespaces.Fx)]
        public Processing? Processing { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("Emisor", Order = 3, Namespace = MxNamespaces.Fx)]
        public Seller? Seller { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("Receptor", Order = 4, Namespace = MxNamespaces.Fx)]
        public Customer? Customer { get; set; }

    }
}
