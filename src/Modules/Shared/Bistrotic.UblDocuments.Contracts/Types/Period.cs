namespace Bistrotic.UblDocuments.Types
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Period
    {
        [DataMember(Order = 6)]
        public IEnumerable<string> Description { get; set; } = Array.Empty<string>();

        [DataMember(Order = 5)]
        public IEnumerable<string> DescriptionCode { get; set; } = Array.Empty<string>();

        [DataMember(Order = 4)]
        public decimal DurationMeasure { get; set; }

        [DataMember(Order = 2)]
        public DateTimeOffset EndDate { get; set; }

        [DataMember(Order = 3)]
        public DateTimeOffset EndTime { get; set; }

        [DataMember(Order = 0)]
        public DateTimeOffset StartDate { get; set; }

        [DataMember(Order = 1)]
        public DateTimeOffset StartTime { get; set; }
    }
}