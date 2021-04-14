namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Country
    {
        [DataMember(Order = 0)]
        public string IdentificationCode { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string Name { get; set; } = string.Empty;
    }
}