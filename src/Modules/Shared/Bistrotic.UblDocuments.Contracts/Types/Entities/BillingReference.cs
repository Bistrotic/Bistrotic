namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class BillingReference
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? InvoiceDocumentReference { get; set; }

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? SelfBilledInvoiceDocumentReference { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? CreditNoteDocumentReference { get; set; }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? SelfBilledCreditNoteDocumentReference { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? DebitNoteDocumentReference { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? ReminderDocumentReference { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public DocumentReference? AdditionalDocumentReference { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<BillingReferenceLine> BillingReferenceLine { get; set; } = new();



    }
}