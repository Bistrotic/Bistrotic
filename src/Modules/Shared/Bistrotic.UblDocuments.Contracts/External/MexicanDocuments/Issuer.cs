﻿namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Emisor", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Emisor", Namespace = MxNamespaces.Cfdi)]
    public class Issuer
    {
        [DataMember(Order = 0)]
        [XmlAttribute("Rfc")]
        public string? Code { get; set; }

        [DataMember(Order = 1)]
        [XmlAttribute("Nombre")]
        public string? Name { get; set; }

        [DataMember(Order = 2)]
        [XmlAttribute("RegimenFiscal")]
        public string? TaxCode { get; set; }
    }
}