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
            invoice.ContractDocumentReference.Should().HaveCount(1);
            var contract = invoice.ContractDocumentReference.First();
            contract.ID.Should().Be("Contract321");
            contract.DocumentType.Should().Be("Framework agreement");
            invoice.AdditionalDocumentReference.Should().HaveCount(2);
            var additionalDocument1 = invoice.AdditionalDocumentReference[0];
            additionalDocument1.ID.Should().Be("Doc1");
            additionalDocument1.DocumentType.Should().Be("Timesheet");
            additionalDocument1.Attachment.ExternalReference.URI.Should().Be("http://www.suppliersite.eu/sheet001.html");
            var additionalDocument2 = invoice.AdditionalDocumentReference[1];
            additionalDocument2.ID.Should().Be("Doc2");
            additionalDocument2.DocumentType.Should().Be("Drawing");
            additionalDocument2.Attachment.EmbeddedDocumentBinaryObject.Should().Be("UjBsR09EbGhjZ0dTQUxNQUFBUUNBRU1tQ1p0dU1GUXhEUzhi");
            var supplier = invoice.AccountingSupplierParty;
            supplier.Should().NotBeNull();
            supplier.Party.Should().NotBeNull();
            supplier.Party.PartyName.Should().NotBeNull();
            supplier.Party.EndpointID.Should().Be("1234567890123");
            supplier.Party.PartyIdentification.Should().HaveCount(1);
            supplier.Party.PartyIdentification[0].ID.Should().Be("Supp123");
            supplier.Party.PartyName.Name.Should().Be("Salescompany ltd.");
            supplier.Party.PostalAddress.ID.Should().Be("1231412341324");
            supplier.Party.PostalAddress.Postbox.Should().Be("5467");
            supplier.Party.PostalAddress.StreetName.Should().Be("Main street");
            supplier.Party.PostalAddress.AdditionalStreetName.Should().Be("Suite 123");
            supplier.Party.PostalAddress.BuildingNumber.Should().Be("1");
            supplier.Party.PostalAddress.Department.Should().Be("Revenue department");
            supplier.Party.PostalAddress.CityName.Should().Be("Big city");
            supplier.Party.PostalAddress.PostalZone.Should().Be("54321");
            supplier.Party.PostalAddress.CountrySubentityCode.Should().Be("RegionA");
            supplier.Party.PostalAddress.Country.IdentificationCode.Should().Be("DK");
            supplier.Party.PartyTaxScheme.Should().HaveCount(1);
            supplier.Party.PartyTaxScheme[0].CompanyID.Should().Be("DK12345");
            supplier.Party.PartyTaxScheme[0].TaxScheme.ID.Should().Be("VAT");
            supplier.Party.PartyLegalEntity.Should().HaveCount(1);
            supplier.Party.PartyLegalEntity[0].RegistrationName.Should().Be("The Sellercompany Incorporated");
            supplier.Party.PartyLegalEntity[0].CompanyID.Should().Be("5402697509");
            supplier.Party.PartyLegalEntity[0].RegistrationAddress.CityName.Should().Be("Big city");
            supplier.Party.PartyLegalEntity[0].RegistrationAddress.CountrySubentity.Should().Be("RegionA");
            supplier.Party.PartyLegalEntity[0].RegistrationAddress.Country.IdentificationCode.Should().Be("DK");
            supplier.Party.Contact.Should().HaveCount(1);
            supplier.Party.Contact[0].Telephone.Should().Be("4621230");
            supplier.Party.Contact[0].Telefax.Should().Be("4621231");
            supplier.Party.Contact[0].ElectronicMail.Should().Be("antonio@salescompany.dk");
            supplier.Party.Person.Should().HaveCount(1);
            supplier.Party.Person[0].FirstName.Should().Be("Antonio");
            supplier.Party.Person[0].FamilyName.Should().Be("M");
            supplier.Party.Person[0].MiddleName.Should().Be("Salemacher");
            supplier.Party.Person[0].JobTitle.Should().Be("Sales manager");

            var customer = invoice.AccountingCustomerParty;
            customer.Should().NotBeNull();
            customer.Party.Should().NotBeNull();
            customer.Party.PartyName.Should().NotBeNull();
            customer.Party.EndpointID.Should().Be("1234567987654");
            customer.Party.PartyIdentification.Should().HaveCount(1);
            customer.Party.PartyIdentification[0].ID.Should().Be("345KS5324");
            customer.Party.PartyName.Name.Should().Be("Buyercompany ltd");
            customer.Party.PostalAddress.ID.Should().Be("1238764941386");
            customer.Party.PostalAddress.Postbox.Should().Be("123");
            customer.Party.PostalAddress.StreetName.Should().Be("Anystreet");
            customer.Party.PostalAddress.AdditionalStreetName.Should().Be("Back door");
            customer.Party.PostalAddress.BuildingNumber.Should().Be("8");
            customer.Party.PostalAddress.Department.Should().Be("Accounting department");
            customer.Party.PostalAddress.CityName.Should().Be("Anytown");
            customer.Party.PostalAddress.PostalZone.Should().Be("101");
            customer.Party.PostalAddress.CountrySubentity.Should().Be("RegionB");
            customer.Party.PostalAddress.Country.IdentificationCode.Should().Be("BE");
            customer.Party.PartyTaxScheme.Should().HaveCount(1);
            customer.Party.PartyTaxScheme[0].CompanyID.Should().Be("BE54321");
            customer.Party.PartyTaxScheme[0].TaxScheme.ID.Should().Be("VAT");
            customer.Party.PartyLegalEntity.Should().HaveCount(1);
            customer.Party.PartyLegalEntity[0].RegistrationName.Should().Be("The buyercompany inc.");
            customer.Party.PartyLegalEntity[0].CompanyID.Should().Be("5645342123");
            customer.Party.PartyLegalEntity[0].RegistrationAddress.CityName.Should().Be("Mainplace");
            customer.Party.PartyLegalEntity[0].RegistrationAddress.CountrySubentity.Should().Be("RegionB");
            customer.Party.PartyLegalEntity[0].RegistrationAddress.Country.IdentificationCode.Should().Be("BE");
            customer.Party.Contact.Should().HaveCount(1);
            customer.Party.Contact[0].Telephone.Should().Be("5121230");
            customer.Party.Contact[0].Telefax.Should().Be("5121231");
            customer.Party.Contact[0].ElectronicMail.Should().Be("john@buyercompany.eu");
            customer.Party.Person.Should().HaveCount(1);
            customer.Party.Person[0].FirstName.Should().Be("John");
            customer.Party.Person[0].FamilyName.Should().Be("X");
            customer.Party.Person[0].MiddleName.Should().Be("Doe");
            customer.Party.Person[0].JobTitle.Should().Be("Purchasing manager");
            var payee = invoice.PayeeParty;
            payee.Should().NotBeNull();
            payee.PartyIdentification.Should().HaveCount(1);
            payee.PartyIdentification[0].ID.Should().Be("098740918237");
            payee.PartyName.Should().NotBeNull();
            payee.PartyName.Name.Should().Be("Ebeneser Scrooge Inc.");
            payee.PartyLegalEntity.Should().HaveCount(1);
            payee.PartyLegalEntity[0].CompanyID.Should().Be("6411982340");
            var delivery = invoice.Delivery;
            delivery.Should().HaveCount(1);
            delivery[0].ActualDeliveryDate.Should().NotBeNull();
            DateTime actualDeliveryDate = delivery[0].ActualDeliveryDate;
            actualDeliveryDate.Year.Should().Be(2009);
            actualDeliveryDate.Month.Should().Be(12);
            actualDeliveryDate.Day.Should().Be(15);
            delivery[0].DeliveryLocation.Should().NotBeNull();
            var deliveryLocation = delivery[0].DeliveryLocation;
            deliveryLocation.ID.Should().Be("6754238987648");
            deliveryLocation.Address.StreetName.Should().Be("Deliverystreet");
            deliveryLocation.Address.AdditionalStreetName.Should().Be("Side door");
            deliveryLocation.Address.BuildingNumber.Should().Be("12");
            deliveryLocation.Address.CityName.Should().Be("DeliveryCity");
            deliveryLocation.Address.PostalZone.Should().Be("523427");
            deliveryLocation.Address.CountrySubentity.Should().Be("RegionC");
            deliveryLocation.Address.Country.IdentificationCode.Should().Be("BE");
            invoice.PaymentMeans.Should().HaveCount(1);
            var paymentMeans = invoice.PaymentMeans[0];
            paymentMeans.PaymentMeansCode.Value.Should().Be("31");
            paymentMeans.PaymentDueDate.Should().NotBeNull();
            DateTime paymentDueDate = paymentMeans.PaymentDueDate;
            paymentDueDate.Year.Should().Be(2009);
            paymentDueDate.Month.Should().Be(12);
            paymentDueDate.Day.Should().Be(31);
            paymentMeans.PaymentChannelCode.Value.Should().Be("IBAN");
            paymentMeans.PaymentID.Should().Be("Payref1");
            paymentMeans.PayeeFinancialAccount.Should().NotBeNull();
            paymentMeans.PayeeFinancialAccount.ID.Should().Be("DK1212341234123412");
            paymentMeans.PayeeFinancialAccount.FinancialInstitutionBranch.FinancialInstitution.ID.Should().Be("DKDKABCD");



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