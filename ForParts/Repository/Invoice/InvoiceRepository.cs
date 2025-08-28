using ForParts.Data;
using ForParts.IRepository.Invoice;
using ForParts.Models.Enums;
using ForParts.Models.Product;
using ForParts.Models.Supply;
using Microsoft.EntityFrameworkCore;
using System;
using InvoiceAlias = ForParts.Models.Invoice.Invoice;


namespace ForParts.Repository.Invoice
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ContextDb _context;

        public InvoiceRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task AddAsync(InvoiceAlias invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<InvoiceAlias?> GetByIdWithItemsAsync(int invoiceId)
        {
            return await _context.Invoices
                .Include(i => i.Items)
                    .ThenInclude(item => item.Product)
                .Include(i => i.Customer)
                    .ThenInclude(c => c.DireccionFiscal)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }

        public async Task<List<InvoiceAlias>> GetAllAsync(DateTime? desde, DateTime? hasta, string? estado)
        {
            var query = _context.Invoices
                .Include(i => i.Items)
                .Include(i => i.Customer)
                .AsQueryable();

            if (desde.HasValue)
                query = query.Where(i => i.InvoiceDateCreate >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(i => i.InvoiceDateCreate <= hasta.Value);

            if (!string.IsNullOrWhiteSpace(estado) && Enum.TryParse<InvoiceState>(estado, out var parsed))
                query = query.Where(i => i.InvoiceState == parsed);

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(InvoiceAlias invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistInInvoice(string codeSupply, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(codeSupply))
                return false;

            // Caso típico: existe tabla de detalle con el SKU/código del insumo
            return await _context.InvoiceItems         // <-- tu DbSet del detalle (cambiá el nombre)
                .AsNoTracking()
                .AnyAsync(inv => inv.Product.ProductoInsumos.Any(s => s.supply.codeSupply == codeSupply), ct);
        }

        public async Task<List<SupplyNecessary>> GetFacturadosByProductIds(List<int> productsId)
        {
           
        
                var ids = productsId?.Distinct().ToArray() ?? Array.Empty<int>();
                if (ids.Length == 0) return new List<SupplyNecessary>();

                // Trae los supplies que están en facturas facturadas y 
                // pertenecen a alguno de los productos indicados.
                return await _context.InvoiceItems
                    .AsNoTracking()
                    .Where(inv =>  ids.Contains(inv.Product.productId)).SelectMany(inv => inv.Product.ProductoInsumos)
                     .Distinct()                 // evita duplicados del mismo supply en varias facturas/productos
                    .ToListAsync();
            }

        public async Task<bool> IsProductInto(string codeProduct)
        {
            if (string.IsNullOrWhiteSpace(codeProduct))
                return false;
            return await _context.Invoices.AsNoTracking().AnyAsync(inv => inv.Items.Any(ii => ii.ProductCode == codeProduct));
        }
    }
}
