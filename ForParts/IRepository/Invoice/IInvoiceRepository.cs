

using ForParts.Models.Product;
using InvoiceAlias = ForParts.Models.Invoice.Invoice;

namespace ForParts.IRepository.Invoice
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Models.Invoice.Invoice invoice);
        Task<InvoiceAlias> GetByIdWithItemsAsync(int invoiceId);
        Task<bool> ExistInInvoice(string codeSupply, CancellationToken ct = default);
        Task<List<SupplyNecessary>> GetFacturadosByProductIds(List<int> productsId);
        Task<bool> IsProductInto(string codeProduct);
    }
}
