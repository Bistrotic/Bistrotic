namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Name = nameof(AccountingContact), Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class AccountingContact
    {
        [DataMember(Order = 4)]
        public string ElectronicMail { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string Name { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string Note { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public IEnumerable<Communication> OtherCommunication { get; set; } = Array.Empty<Communication>();

        [DataMember(Order = 3)]
        public string Telefax { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string Telephone { get; set; } = string.Empty;
    }
}