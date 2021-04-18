
namespace Bistrotic.UblDocuments.Types.ValueTypes
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    [XmlType(Namespace = UblNamespaces.CommonBasicComponents2)]
    public class DescriptionCode : Code
    {

    }
}
