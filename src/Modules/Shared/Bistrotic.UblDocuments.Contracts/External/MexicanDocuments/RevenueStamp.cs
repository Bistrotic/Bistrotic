namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("TimbreFiscalDigital", Namespace = MxNamespaces.Tfd)]
    [XmlRoot("TimbreFiscalDigital", Namespace = MxNamespaces.Tfd)]
    public class RevenueStamp
    {
        [DataMember(Order = 0)]
        [XmlAttribute]
        public string? Version { get; set; }

        [DataMember(Order = 1)]
        [XmlAttribute()]
        public string? UUID { get; set; }
    }
}
