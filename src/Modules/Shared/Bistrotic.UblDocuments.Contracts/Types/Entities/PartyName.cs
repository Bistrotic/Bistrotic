namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class PartyName
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string Name { get; set; } = string.Empty;
    }
}