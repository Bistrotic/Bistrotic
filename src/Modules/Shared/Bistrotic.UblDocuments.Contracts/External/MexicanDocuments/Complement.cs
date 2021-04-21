namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Complemento", Namespace = MxNamespaces.Cfdi)]
    [XmlRoot("Complemento", Namespace = MxNamespaces.Cfdi)]
    public class Complement
    {
        [DataMember(Order = 0)]
        [XmlElement("TimbreFiscalDigital", Order = 0, Namespace = MxNamespaces.Tfd)]
        public RevenueStamp? RevenueStamp { get; set; }
    }
}
