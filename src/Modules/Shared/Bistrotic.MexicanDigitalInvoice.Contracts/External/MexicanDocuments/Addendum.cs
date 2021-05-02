namespace Bistrotic.MexicanDigitalInvoice.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using ProtoBuf;

    [Serializable]
    [DataContract, ProtoContract]
    [XmlType("Addenda", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Addenda", Namespace = MxNamespaces.Cfdi)]
    public class Addendum
    {
        [DataMember(Order = 0), ProtoMember(0)]
        [XmlElement("FactDocMX", Order = 0, Namespace = MxNamespaces.Fx)]
        public Invoice? Invoice { get; set; }
    }
}