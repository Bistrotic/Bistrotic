namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class ExternalReference
    {
        [DataMember(Order = 8)]
        public string CharacterSetCode { get; set; } = string.Empty;

        [DataMember(Order = 10)]
        public string Description { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string DocumentHash { get; set; } = string.Empty;

        [DataMember(Order = 7)]
        public string EncodingCode { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public DateTimeOffset ExpiryDate { get; set; }

        [DataMember(Order = 4)]
        public DateTime ExpiryTime { get; set; }

        [DataMember(Order = 9)]
        public string FileName { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public string FormatCode { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public string HashAlgorithmMethod { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string MimeCode { get; set; } = string.Empty;

        [DataMember(Order = 0)]
        public string URI { get; set; } = string.Empty;
    }
}