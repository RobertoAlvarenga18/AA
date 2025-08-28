using ForParts.DTOs.Zureo;
using InvoiceAlias = ForParts.Models.Invoice.Invoice;

namespace ForParts.IService.Cliente
{
    public interface IZureoInvoiceService
    {
        public Task<ZureoResponseDto> EmitirAsync(InvoiceAlias invoice);
    }
}
