namespace Bistrotic.Application.UblDocument
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    using UblSharp;

    public static class UblHelper
    {
        public static IEnumerable<InvoiceType> GetEmbeddedUblInvoices(this XDocument document)
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
            return xDocs.ConvertAll(p => UblDocument.Parse<InvoiceType>(p));
        }

        public static bool IsUblInvoiceDocument(this string document)
            => !string.IsNullOrWhiteSpace(document)
                && document.Contains("http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.1.xsd", System.StringComparison.InvariantCultureIgnoreCase);

        public static dynamic ToDynamic(this InvoiceType invoice)
        {
            dynamic inv = new ExpandoObject();
            var invoiceDict = (IDictionary<string, object?>)inv;
            inv.ID = invoice.ID.Value;
            inv.DueDate = invoice.DueDate.Value;
            inv.DocumentCurrencyCode = invoice.DocumentCurrencyCode.Value;
            inv.IssueDate = invoice.IssueDate.Value;
            inv.LegalMonetaryTotal.TaxInclusiveAmount = invoice.LegalMonetaryTotal.TaxInclusiveAmount.Value;
            inv.LegalMonetaryTotal.TaxExclusiveAmount = invoice.LegalMonetaryTotal.TaxExclusiveAmount.Value;
            inv.LineCountNumeric = invoice.LineCountNumeric.Value;
            inv.BuyerCustomerParty.SupplierAssignedAccountID = invoice.BuyerCustomerParty.SupplierAssignedAccountID.Value;
            inv.InvoiceLine = invoice.InvoiceLine.ConvertAll(line =>
            {
                dynamic l = new ExpandoObject();
                l.ID = line.ID.Value;
                l.InvoicedQuantity = line.InvoicedQuantity.Value;
                return l;
            });
            return inv;
        }
    }
}