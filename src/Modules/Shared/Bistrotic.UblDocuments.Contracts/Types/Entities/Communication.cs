namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Name = nameof(Communication), Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Communication
    {
        [DataMember(Order = 1)]
        public string Channel { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string ChannelCode { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string Value { get; set; } = string.Empty;
    }
}