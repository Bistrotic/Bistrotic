namespace Bistrotic.UblDocuments.Tests
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using Bistrotic.Application.UblDocument.Tests.Fixtures;
    using Bistrotic.UblDocuments;
    using Bistrotic.UblDocuments.Types.Aggregates;

    using FluentAssertions;

    using Xunit;

    public class UblHelperTest
    {
        [Fact]
        public void UblInvoice_Trivial_2_1_check_all_values()
        {
            using FileStream fs = new(UblTextDocument.Invoice2TrivialFile, FileMode.Create);
            fs.Position = 0;
            XmlSerializer xs = new(typeof(Invoice));
            var invoice = (Invoice)xs.Deserialize(fs);

            invoice.Should().NotBeNull();
            invoice.ID.Should().Be("123");
            /*
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
                     var supplier = invoice.AccountingSupplierParty;
                     supplier.Should().NotBeNull();
                     supplier.Party.Should().NotBeNull();
                     supplier.Party.PartyName.Name.Should().Be("Custom Cotter Pins");
                     var customer = invoice.AccountingCustomerParty;
                     customer.Should().NotBeNull();
                     customer.Party.Should().NotBeNull();
                     customer.Party.PartyName.Name.Should().Be("North American Veeblefetzer");
                     invoice.LegalMonetaryTotal.Should().NotBeNull();
                     invoice.LegalMonetaryTotal.PayableAmount.Should().Be(100.25m);
                     var lines = invoice.InvoiceLine;
                     lines.Should().NotBeNull();
                     lines.Should().HaveCount(1);
                     var line = lines.First();
                     line.ID.Should().Be("1");
                     line.LineExtensionAmount.Should().Be(101.36m);
                     line.Item.Should().NotBeNull();
                     line.Item.Description.Should().Be("Cotter pin, MIL-SPEC");
            */
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