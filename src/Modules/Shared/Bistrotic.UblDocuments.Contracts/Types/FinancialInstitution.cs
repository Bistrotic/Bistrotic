namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class FinancialInstitution
    {
        [DataMember(Order = 2)]
        public Address Address { get; set; } = new();

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string Name { get; set; } = string.Empty;
    }
}