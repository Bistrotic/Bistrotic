﻿namespace Bistrotic.MexicanDigitalInvoice.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Emisor", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Emisor", Namespace = MxNamespaces.Fx)]
    public class Seller
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("DomicilioFiscal", Order = 0)]
        public Address? TaxResidence { get; set; }
    }
}