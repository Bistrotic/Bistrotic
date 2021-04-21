namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Addenda", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Addenda", Namespace = MxNamespaces.Cfdi)]
    public class Addendum
    {
        [DataMember(Order = 1)]
        [XmlElement("FactDocMX", Order = 1, Namespace = MxNamespaces.Fx)]
        public Invoice? Invoice { get; set; }
    }
}
