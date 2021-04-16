namespace Bistrotic.UblDocuments.Tests
{
    using System;
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
        public void UblInvoice_Trivial_2_1_example_check_all_values()
        {
            using FileStream fs = new(UblTextDocument.Invoice2TrivialFile, FileMode.Open);
            XmlSerializer xs = new(typeof(Invoice));
            var invoice = (Invoice)xs.Deserialize(fs);
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
            var supplier = invoice.AccountingSupplierParty;
            supplier.Should().NotBeNull();
            supplier.Party.Should().NotBeNull();
            supplier.Party.PartyName.Should().NotBeNull();
            supplier.Party.PartyName.Name.Should().Be("Custom Cotter Pins");
            var customer = invoice.AccountingCustomerParty;
            customer.Should().NotBeNull();
            customer.Party.Should().NotBeNull();
            customer.Party.PartyName.Should().NotBeNull();
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
        }
        [Fact]
        public void UblInvoice_2_1_example_check_all_values()
        {
            using FileStream fs = new(UblTextDocument.Invoice2File, FileMode.Open);
            XmlSerializer xs = new(typeof(Invoice));
            var invoice = (Invoice)xs.Deserialize(fs);
            invoice.Should().NotBeNull();
            invoice.UBLVersionID.Should().Be("2.1");
            invoice.ID.Should().Be("TOSL108");
            DateTime issueDate = invoice.IssueDate;
            issueDate.Year.Should().Be(2009);
            issueDate.Month.Should().Be(12);
            issueDate.Day.Should().Be(15);
            invoice.InvoiceTypeCode.Value.Should().Be("380");
            invoice.InvoiceTypeCode.ListID.Should().Be("UN/ECE 1001 Subset");
            invoice.InvoiceTypeCode.ListAgencyID.Should().Be("6");
            invoice.Note.LanguageID.Should().Be("en");
            invoice.Note.Value.Should().Be("Ordered in our booth at the convention.");
            DateTime taxDate = invoice.TaxPointDate;
            taxDate.Year.Should().Be(2009);
            taxDate.Month.Should().Be(11);
            taxDate.Day.Should().Be(30);
            invoice.DocumentCurrencyCode.Value.Should().Be("EUR");
            invoice.DocumentCurrencyCode.ListID.Should().Be("ISO 4217 Alpha");
            invoice.DocumentCurrencyCode.ListAgencyID.Should().Be("6");
            invoice.AccountingCost.Should().Be("Project cost code 123");
            invoice.InvoicePeriod.Should().NotBeNull();
            invoice.InvoicePeriod.EndDate.Should().NotBeNull();
            invoice.InvoicePeriod.StartDate.Should().NotBeNull();
            DateTime startDate = invoice.InvoicePeriod.StartDate ?? throw new NullReferenceException();
            startDate.Year.Should().Be(2009);
            startDate.Month.Should().Be(11);
            startDate.Day.Should().Be(1);
            DateTime endDate = invoice.InvoicePeriod.EndDate ?? throw new NullReferenceException();
            endDate.Year.Should().Be(2009);
            endDate.Month.Should().Be(11);
            endDate.Day.Should().Be(30);
            invoice.OrderReference.ID.Should().Be("123");
            var supplier = invoice.AccountingSupplierParty;

            supplier.Should().NotBeNull();
            supplier.Party.Should().NotBeNull();
            supplier.Party.PartyName.Should().NotBeNull();
            supplier.Party.PartyName.Name.Should().Be("Custom Cotter Pins");
            var customer = invoice.AccountingCustomerParty;
            customer.Should().NotBeNull();
            customer.Party.Should().NotBeNull();
            customer.Party.PartyName.Should().NotBeNull();
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
        }

        [Fact]
        public void IsUblInvoiceDocument_is_true()
        {
            var doc = UblTextDocument.GetInvoice2_1TrivialExampleString();
            doc.IsUblInvoiceDocument().Should().BeTrue();
        }
        [Fact]
        public void Can_read_Invoice2_trivial_file()
        {
            File.Exists(UblTextDocument.Invoice2TrivialFile).Should().BeTrue();
            var doc = File.ReadAllBytes(UblTextDocument.Invoice2TrivialFile);
            doc.Length.Should().BeGreaterThan(100);
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