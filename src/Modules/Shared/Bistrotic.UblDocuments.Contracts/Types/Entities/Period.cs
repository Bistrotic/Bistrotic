namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract(Namespace = "")]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Period
    {
        /*
        [DataMember(Order = 6)]
        public IEnumerable<string> Description { get; set; } = Array.Empty<string>();

        [DataMember(Order = 5)]
        public IEnumerable<string> DescriptionCode { get; set; } = Array.Empty<string>();
        */
        [DataMember(Order = 4)]
        public decimal DurationMeasure { get; set; }

        [DataMember(Order = 2, IsRequired = true)]

        public DateType? EndDate { get; set; }

        [DataMember(Order = 0)]
        public DateType? StartDate { get; set; }

        [DataMember(Order = 3)]
        public TimeType? EndTime { get; set; }

        [DataMember(Order = 1)]
        public TimeType? StartTime { get; set; }
    }
}