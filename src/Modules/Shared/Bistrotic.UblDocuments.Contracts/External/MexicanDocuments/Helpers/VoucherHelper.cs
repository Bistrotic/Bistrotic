namespace Bistrotic.UblDocuments.External.MexicanDocuments.Helpers
{
    using Bistrotic.UblDocuments.Types.Entities;

    using UblInvoice = Bistrotic.UblDocuments.Types.Aggregates.Invoice;
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
