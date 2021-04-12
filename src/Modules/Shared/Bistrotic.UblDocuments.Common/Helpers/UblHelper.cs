namespace Bistrotic.UblDocuments
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using Bistrotic.UblDocuments.Types;

    public static class UblHelper
    {
        public static IEnumerable<Invoice> GetEmbeddedUblInvoices(this XDocument document)
        {
            List<string> xDocs = document
                .DescendantNodes()
                .Where(p => p.NodeType == XmlNodeType.CDATA
                    && p?
                        .Parent?
                        .Value?
                        .Contains("http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.1.xsd",
                            System.StringComparison.InvariantCultureIgnoreCase) == true)
                .Select(p => p?.Parent?.Value?.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .OfType<string>()
                .ToList();
            XmlSerializer serializer = new(typeof(Invoice));
            return xDocs.ConvertAll(p =>
            {
                using XmlTextReader reader = new(p);

                return (Invoice)(serializer.Deserialize(reader) ?? throw new SerializationException($"Error while deserializing {nameof(Invoice)} :\n" + p));
            });
        }

        public static bool IsUblInvoiceDocument(this string document)
            => !string.IsNullOrWhiteSpace(document)
                && document.Contains("http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.1.xsd", System.StringComparison.InvariantCultureIgnoreCase);
    }
}