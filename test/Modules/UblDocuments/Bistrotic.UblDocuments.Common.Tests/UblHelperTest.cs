namespace Bistrotic.UblDocuments.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Bistrotic.Application.UblDocument.Tests.Fixtures;
    using Bistrotic.UblDocuments;
    using Bistrotic.UblDocuments.Types;

    using FluentAssertions;

    using Xunit;

    public class UblHelperTest
    {
        [Fact]
        public void GetEmbeddedUblInvoices()
        {
            var doc = UblTextDocument.GetDocument();
            IEnumerable<Invoice> invoices = doc.GetEmbeddedUblInvoices();
            invoices.Should().HaveCount(1);
            var invoice = invoices.First();
            invoice.LineCountNumeric.Should().Be(1);
        }

        [Fact]
        public void IsUblInvoiceDocument_is_true()
        {
            var doc = UblTextDocument.GetString();
            doc.IsUblInvoiceDocument().Should().BeTrue();
        }
    }
}