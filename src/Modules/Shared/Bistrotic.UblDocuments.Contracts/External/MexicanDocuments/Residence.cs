namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Domicilio", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Domicilio", Namespace = MxNamespaces.Fx)]
    public class Residence
    {
        [DataMember(Order = 0)]
        [XmlElement("DomicilioFiscalMexicano", Order = 0)]
        public Address? TaxResidence { get; set; }

    }
}
