
namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType(nameof(OrderTypeCode) + "Type", Namespace = UblNamespaces.CommonBasicComponents2)]
    public class OrderTypeCode : CodeType
    {

    }
}
