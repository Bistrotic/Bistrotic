namespace Bistrotic.UblDocuments.Tests
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;

    using Bistrotic.Application.UblDocument.Tests.Fixtures;
    using Bistrotic.UblDocuments;
    using Bistrotic.UblDocuments.Types;

    using FluentAssertions;

    using Xunit;

    public class UblHelperTest
    {
        [Fact]
        public void GetUblInvoices()
        {
            var doc = UblTextDocument.GetInvoice2_1TrivialExampleString();
            using StringReader text = new(doc);
            using XmlTextReader stringReader = new(text);
            DataContractSerializer serializer = new(typeof(Invoice));
            var invoice = (Invoice)serializer.ReadObject(stringReader);
            invoice.Should().NotBeNull();
            invoice.ID.Should().Be("123");
            invoice.IssueDate.Year.Should().Be(2011);
            invoice.IssueDate.Month.Should().Be(9);
            invoice.IssueDate.Day.Should().Be(22);
        }

        [Fact]
        public void IsUblInvoiceDocument_is_true()
        {
            var doc = UblTextDocument.GetInvoice2_1TrivialExampleString();
            doc.IsUblInvoiceDocument().Should().BeTrue();
        }
    }
}