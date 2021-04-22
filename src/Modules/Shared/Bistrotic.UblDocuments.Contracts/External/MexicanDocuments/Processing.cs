namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Procesamiento", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Procesamiento", Namespace = MxNamespaces.Fx)]
    public class Processing
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0)]
        public DictionarySet? Dictionary { get; set; } = new();
    }
}
