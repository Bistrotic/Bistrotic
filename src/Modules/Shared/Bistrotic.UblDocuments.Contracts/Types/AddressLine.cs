namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class AddressLine
    {
        [DataMember(Order = 0)]
        public string Line { get; set; } = string.Empty;
    }
}