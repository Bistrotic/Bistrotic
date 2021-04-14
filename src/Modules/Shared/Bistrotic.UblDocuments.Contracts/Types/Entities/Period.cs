namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Bistrotic.UblDocuments.Types.ValueTypes;

    [Serializable]
    [DataContract(Namespace = "")]
    public class Period
    {
        [DataMember(Order = 6)]
        public IEnumerable<string> Description { get; set; } = Array.Empty<string>();

        [DataMember(Order = 5)]
        public IEnumerable<string> DescriptionCode { get; set; } = Array.Empty<string>();

        [DataMember(Order = 4)]
        public decimal DurationMeasure { get; set; }

        [DataMember(Name = nameof(EndDate), Order = 2, IsRequired = true)]
        private string? _endDate;
        [IgnoreDataMember]
        public DateTime? EndDate
        {
            get => new NullableDateType(_endDate);
            set => _endDate = new NullableDateType(value);
        }

        [DataMember(Name = nameof(StartDate), Order = 0)]
        private string? _startDate;
        [IgnoreDataMember]
        public DateTime? StartDate
        {
            get => new NullableDateType(_startDate);
            set => _startDate = new NullableDateType(value);
        }

        [DataMember(Name = nameof(EndTime), Order = 3)]
        private string? _endTime;
        [IgnoreDataMember]
        public DateTime? EndTime
        {
            get => new NullableTimeType(_endTime);
            set => _endTime = new NullableTimeType(value);
        }
        [DataMember(Name = nameof(StartTime), Order = 1)]
        private string? _startTime;
        [IgnoreDataMember]
        public DateTime? StartTime
        {
            get => new NullableTimeType(_startTime);
            set => _startTime = new NullableTimeType(value);
        }
    }
}