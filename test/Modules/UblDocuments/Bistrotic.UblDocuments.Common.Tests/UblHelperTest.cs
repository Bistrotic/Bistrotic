namespace Bistrotic.Application.UblDocument.Tests
{
    using Bistrotic.Application.UblDocument.Tests.Fixtures;

    using FluentAssertions;

    using Xunit;
    using System.Linq;
    using System.Collections.Generic;
    using UblSharp;

    public class UblHelperTest
    {
        [Fact]
        public void GetEmbeddedUblInvoices()
        {
            var doc = UblTextDocument.GetDocument();
            IEnumerable<InvoiceType> invoices = doc.GetEmbeddedUblInvoices();
            invoices.Should().HaveCount(1);
            var invoice = invoices.First();
            invoice.LineCountNumeric.Value.Should().Be(1);
        }

        [Fact]
        public void IsUblInvoiceDocument_is_true()
        {
            var doc = UblTextDocument.GetString();
            doc.IsUblInvoiceDocument().Should().BeTrue();
        }
    }
}