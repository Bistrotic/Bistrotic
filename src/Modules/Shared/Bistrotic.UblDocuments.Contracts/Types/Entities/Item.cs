﻿namespace Bistrotic.UblDocuments.Types.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = UblNamespaces.CommonAggregateComponents2)]
    [XmlType(Namespace = UblNamespaces.CommonAggregateComponents2)]
    public class Item
    {
        [DataMember(Order = 0)]
        [XmlElement(Order = 0, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Description { get; set; }

        [DataMember(Order = 1)]
        [XmlElement(Order = 1, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PackQuantity { get; set; }

        [DataMember(Order = 2)]
        [XmlElement(Order = 2, Namespace = UblNamespaces.CommonBasicComponents2)]
        public decimal PackSizeNumeric { get; set; }

        [DataMember(Order = 3)]
        [XmlElement(Order = 3, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool CatalogueIndicator { get; set; }

        [DataMember(Order = 4)]
        [XmlElement(Order = 4, Namespace = UblNamespaces.CommonBasicComponents2)]
        public string? Name { get; set; }

        [DataMember(Order = 5)]
        [XmlElement(Order = 5, Namespace = UblNamespaces.CommonBasicComponents2)]
        public bool HazardousRiskIndicator { get; set; }

        [DataMember(Order = 6)]
        [XmlElement(Order = 6, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> AdditionalInformation { get; set; } = new();

        [DataMember(Order = 7)]
        [XmlElement(Order = 7, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> Keyword { get; set; } = new();

        [DataMember(Order = 8)]
        [XmlElement(Order = 8, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> BrandName { get; set; } = new();

        [DataMember(Order = 9)]
        [XmlElement(Order = 9, Namespace = UblNamespaces.CommonBasicComponents2)]
        public List<string> ModelName { get; set; } = new();

        [DataMember(Order = 10)]
        [XmlElement(Order = 10, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public ItemIdentification? BuyersItemIdentification { get; set; }

        [DataMember(Order = 11)]
        [XmlElement(Order = 11, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public ItemIdentification? SellersItemIdentification { get; set; }

        [DataMember(Order = 12)]
        [XmlElement(Order = 12, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<ItemIdentification> ManufacturersItemIdentification { get; set; } = new();

        [DataMember(Order = 13)]
        [XmlElement(Order = 13, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public ItemIdentification? StandardItemIdentification { get; set; }

        [DataMember(Order = 14)]
        [XmlElement(Order = 14, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public ItemIdentification? CatalogueItemIdentification { get; set; }

        [DataMember(Order = 15)]
        [XmlElement(Order = 15, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<ItemIdentification> AdditionalItemIdentification { get; set; } = new();

        [DataMember(Order = 16)]
        [XmlElement(Order = 16, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public DocumentReference? CatalogueDocumentReference { get; set; }

        [DataMember(Order = 17)]
        [XmlElement(Order = 17, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<DocumentReference> ItemSpecificationDocumentReference { get; set; } = new();

        [DataMember(Order = 18)]
        [XmlElement(Order = 18, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public Country? OriginCountry { get; set; }

        [DataMember(Order = 19)]
        [XmlElement(Order = 19, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<CommodityClassification> CommodityClassification { get; set; } = new();

        [DataMember(Order = 20)]
        [XmlElement(Order = 20, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<TransactionConditions> TransactionConditions { get; set; } = new();

        [DataMember(Order = 22)]
        [XmlElement(Order = 22, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<TaxCategory> ClassifiedTaxCategory { get; set; } = new();

        [DataMember(Order = 23)]
        [XmlElement(Order = 23, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<ItemProperty> AdditionalItemProperty { get; set; } = new();

        [DataMember(Order = 24)]
        [XmlElement(Order = 24, Namespace = UblNamespaces.CommonAggregateComponents2)]
        public List<Party> ManufacturerParty { get; set; } = new();
    }
}