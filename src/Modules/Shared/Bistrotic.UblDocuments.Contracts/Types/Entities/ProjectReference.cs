namespace Bistrotic.UblDocuments.Types.Entities
{
    using Bistrotic.UblDocuments.Types.ValueTypes;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class ProjectReference
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? ID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? UUID { get; set; } = string.Empty;

        [DataMember(Order = 2, IsRequired = true)]
        [XmlIgnore]
        public DateTimeOffset? IssueDateTime { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        [XmlElement(Order = 2, IsNullable = false, Namespace = UblNamespaces.CommonBasicComponents2)]
        public Date? IssueDate
        {
            get => (IssueDateTime == null) ? null : new(IssueDateTime.Value);
            set => IssueDateTime = (value == null) ? null : (DateTime)value;
        }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<WorkPhaseReference> WorkPhaseReference { get; set; } = new();
    }
}