using ForParts.Data;
using ForParts.Exceptions.Product;
using ForParts.Exceptions.Supply;
using ForParts.IRepository.Product;
using ForParts.Models.Enums;
using ForParts.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace ForParts.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDb _contextDb;
        public ProductRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
    

        public async Task<bool> AddAsync(Product product)
        {
            if (product is null)
                throw new ProductException("Datos incorrectos.");

            // Normalizo el código
            product.codeProduct = product.codeProduct?.Trim();

            // Verifico duplicado (usar AnyAsync)
            var exists = await _contextDb.Products
                .AsNoTracking()
                .AnyAsync(p => p.codeProduct == product.codeProduct);

            if (exists)
                throw new ProductException($"Ya existe un producto creado con el código {product.codeProduct}.");

            

            // Persiste
            var success = await _contextDb.AddAsync(product);
            var rows = await _contextDb.SaveChangesAsync();
            return rows > 0;
        }

        

        public async Task AddStockMovementAsync(ProductMovement nuevoMovimientoStock)
        {
            throw new NotImplementedException();

        }
    public async Task<bool> ExistProductAsync(string codeProduct)
        {
            if (string.IsNullOrWhiteSpace(codeProduct))
                return false;

            var normalized = codeProduct.Trim();
            return await _contextDb.Products.AsNoTracking().AnyAsync(p => p.codeProduct == normalized);

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _contextDb.Products.AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<Product>> GetAllStockMovements()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByCodeAsync(string codeProduct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsUsingSupply(string codeSupply)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductWithSupplies(string codeProduct)
        {
            throw new NotImplementedException();
        }

        public Task GetStockByCode(string codeSupply)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product exist)
        {
            throw new NotImplementedException();
        }
    }
}
