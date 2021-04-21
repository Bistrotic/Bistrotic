namespace Bistrotic.UblDocuments.External.MexicanDocuments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType("Procesamiento", Namespace = MxNamespaces.Fx)]
    [XmlRoot("Procesamiento", Namespace = MxNamespaces.Fx)]
    public class Processing
    {

        [XmlIgnore]
        public Dictionary<string, string?>? Dictionary { get; set; }

        [XmlArray("Dictionary")]
        [XmlArrayItem("Entry")]
        public (string k, string? v)[] InternalDictionary
        {
            get
            {
                return (Dictionary == null)
                    ? Array.Empty<(string k, string? v)>()
                    : Dictionary.Select(p => (p.Key, p.Value)).ToArray();
            }
            set
            {
                Dictionary = value?.ToDictionary(p => p.k, p => p.v);
            }
        }

    }
}
