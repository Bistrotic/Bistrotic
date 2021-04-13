﻿namespace Bistrotic.UblDocuments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    using Bistrotic.UblDocuments.Types;

    using ExtendedXmlSerializer;
    using ExtendedXmlSerializer.Configuration;

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
                        .Contains(UblNamespaces.Invoice2,
                            System.StringComparison.InvariantCultureIgnoreCase) == true)
                .Select(p => p?.Parent?.Value?.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .OfType<string>()
                .ToList();
            IExtendedXmlSerializer serializer = new ConfigurationContainer().Create();
            return xDocs.ConvertAll(p => serializer.Deserialize<Invoice>(p));
        }


        public static bool IsUblInvoiceDocument(this string document)
            => !string.IsNullOrWhiteSpace(document)
                && document.Contains(UblNamespaces.Invoice2, System.StringComparison.InvariantCultureIgnoreCase);
        public static Invoice ToInvoice(this string document)
        {
            IExtendedXmlSerializer serializer = new ConfigurationContainer()
                .Type<Invoice>()
                .Create();
            return serializer.Deserialize<Invoice>(document);
        }
    }
}