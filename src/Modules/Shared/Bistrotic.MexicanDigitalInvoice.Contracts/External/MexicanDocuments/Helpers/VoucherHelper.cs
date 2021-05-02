namespace Bistrotic.MexicanDigitalInvoice.External.MexicanDocuments.Helpers
{
    using Bistrotic.MexicanDigitalInvoice.Types.Entities;

    using UblInvoice = Bistrotic.MexicanDigitalInvoice.Types.Aggregates.Invoice;

    public static class VoucherHelper
    {
        public static UblInvoice ToUblInvoice(this Voucher voucher)
        {
            SupplierParty seller = new SupplierParty()
            {
                Party = new Party()
                {
                    FinancialAccount = new FinancialAccount() { ID = voucher.Issuer?.Code }
                }
            };
            return new UblInvoice()
            {
                ID = voucher.InvoiceId,
                SellerSupplierParty = seller
            };
        }
    }
}