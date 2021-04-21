﻿namespace Bistrotic.UblDocuments.Common.Tests
{
    using System.IO;
    using System.Xml.Serialization;

    using Bistrotic.Application.UblDocument.Tests.Fixtures;
    using Bistrotic.UblDocuments.External.MexicanDocuments;

    using FluentAssertions;

    using Xunit;

    public class MxDeserializeTest
    {
        [Fact]
        public void UblInvoice_2_1_from_embedded_check()
        {
            using FileStream fs = new(MxTextDocument.MexicanInvoiceFile, FileMode.Open);
            XmlSerializer xs = new(typeof(Voucher));
            var voucher = (Voucher)xs.Deserialize(fs);
            voucher.Should().NotBeNull();
            voucher.Issuer.Should().NotBeNull();
            voucher.Issuer.Code.Should().Be("DIOR02525DXA");
            voucher.Issuer.Name.Should().Be("GLOBAL CONSOLIDATED DIOR MEXICO S DE RL DE CV");
            voucher.Issuer.TaxCode.Should().Be("601");
            voucher.Receiver.Should().NotBeNull();
            voucher.Receiver.Code.Should().Be("CUST00422000");
            voucher.Receiver.Name.Should().Be("GRUPO VENTA INTERNACIONAL, S.A. DE C.V.");
            voucher.Receiver.UsageCode.Should().Be("G01");
            voucher.TaxItems.Should().NotBeNull();
            voucher.TaxItems.Items.Should().HaveCount(6);
            voucher.TaxItems.Items[0].ItemCode.Should().Be("42295509");
            voucher.TaxItems.Items[1].ItemCode.Should().Be("42295509");
            voucher.TaxItems.Items[2].ItemCode.Should().Be("42295509");
            voucher.TaxItems.Items[3].ItemCode.Should().Be("42295509");
            voucher.TaxItems.Items[4].ItemCode.Should().Be("42295509");
            voucher.TaxItems.Items[5].ItemCode.Should().Be("42295509");
            voucher.TaxItems.Items[0].Quantity.Should().Be(24);
            voucher.TaxItems.Items[1].Quantity.Should().Be(2);
            voucher.TaxItems.Items[2].Quantity.Should().Be(2);
            voucher.TaxItems.Items[3].Quantity.Should().Be(4);
            voucher.TaxItems.Items[4].Quantity.Should().Be(24);
            voucher.TaxItems.Items[5].Quantity.Should().Be(5);
            voucher.Tax.Should().NotBeNull();
            voucher.Tax.Total.Should().Be(1351.66m);
            voucher.Tax.Transactions.Should().NotBeNull();
            voucher.Tax.Transactions.Transaction.Should().HaveCount(1);
            voucher.Tax.Transactions.Transaction[0].TaxCode.Should().Be("002");
            voucher.Tax.Transactions.Transaction[0].FactorType.Should().Be("Tasa");
            voucher.Tax.Transactions.Transaction[0].Percent.Should().Be(0.16m);
            voucher.Tax.Transactions.Transaction[0].Amount.Should().Be(1351.66m);
            voucher.Complement.Should().NotBeNull();
            voucher.Complement.RevenueStamp.Should().NotBeNull();
            voucher.Complement.RevenueStamp.Version.Should().Be("1.1");
            voucher.Addendum.Should().NotBeNull();
            var invoice = voucher.Addendum.Invoice;
            invoice.Should().NotBeNull();
            invoice.Identification.IssuerCountryCode.Should().Be("MX");
            invoice.Identification.DocumentType.Should().Be("FACTURA");
            invoice.Identification.IssuerCode.Should().Be("DIOR02525DXA");
            invoice.Identification.IssuerName.Should().Be("GLOBAL CONSOLIDATED DIOR MEXICO S DE RL DE CV");
            invoice.Identification.UserCode.Should().Be("DIOR02525DXAUser");
            invoice.Identification.DeliveryLocation.Should().Be("06500");
            invoice.Identification.Signature.Should().Be("3qe7qlscQY62tlnEM3JMsxA3WXSQ==");

        }
    }
}