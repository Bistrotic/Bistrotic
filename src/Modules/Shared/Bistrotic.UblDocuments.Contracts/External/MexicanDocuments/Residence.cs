﻿namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using ProtoBuf;

    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Domicilio", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Domicilio", Namespace = MxNamespaces.Fx)]
    public class Residence
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("DomicilioFiscalMexicano", Order = 0)]
        public Address? TaxResidence { get; set; }

    }
}
