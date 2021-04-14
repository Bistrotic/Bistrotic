namespace Bistrotic.UblDocuments.Tests
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml.Linq;

    using Bistrotic.Application.UblDocument.Tests.Fixtures;
    using Bistrotic.UblDocuments;
    using Bistrotic.UblDocuments.Types.Aggregates;

    using FluentAssertions;

    using Xunit;

    public class UblHelperTest
    {
        [Fact]
        public void GetUblInvoices()
        {
            var xDocumentOriginal = XDocument.Load(UblTextDocument.Invoice2TrivialFile, LoadOptions.None);
            DataContractSerializer serializer = new(typeof(Invoice));
            var invoice = (Invoice)serializer.ReadObject(xDocumentOriginal.Root.RemoveAllNamespaces().CreateReader());
            invoice.Should().NotBeNull();
            invoice.ID.Should().Be("123");
            DateTime issueDate = invoice.IssueDate;
            issueDate.Year.Should().Be(2011);
            issueDate.Month.Should().Be(9);
            issueDate.Day.Should().Be(22);
            invoice.InvoicePeriod.Should().NotBeNull();
            invoice.InvoicePeriod.EndDate.Should().NotBeNull();
            invoice.InvoicePeriod.StartDate.Should().NotBeNull();
            DateTime startDate = invoice.InvoicePeriod.StartDate ?? throw new NullReferenceException();
            startDate.Year.Should().Be(2011);
            startDate.Month.Should().Be(8);
            startDate.Day.Should().Be(1);
            DateTime endDate = invoice.InvoicePeriod.EndDate ?? throw new NullReferenceException();
            endDate.Year.Should().Be(2011);
            endDate.Month.Should().Be(8);
            endDate.Day.Should().Be(31);
        }

        [Fact]
        public void IsUblInvoiceDocument_is_true()
        {
            var doc = UblTextDocument.GetInvoice2_1TrivialExampleString();
            doc.IsUblInvoiceDocument().Should().BeTrue();
        }
        [Fact]
        public void RemoveNameSpaces()
        {
            var xDocumentOriginal = XDocument.Load(UblTextDocument.Invoice2TrivialFile, LoadOptions.None);
            xDocumentOriginal.Should().NotBeNull();
            xDocumentOriginal.Root.Should().NotBeNull();
            xDocumentOriginal
                .Root
                .Attributes()
                .Where(attr => attr.IsNamespaceDeclaration)
                .ToList()
                .Should().NotBeEmpty();

            var xDocumentNew = XDocument.Parse(xDocumentOriginal.Root.RemoveAllNamespaces().ToString(), LoadOptions.None);
            xDocumentNew.Should().NotBeNull();
            xDocumentNew.Root.Should().NotBeNull();
            xDocumentNew
                .Root
                .Attributes()
                .Where(attr => attr.IsNamespaceDeclaration)
                .ToList()
                .Should().BeEmpty();

        }
    }
}