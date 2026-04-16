using Microsoft.EntityFrameworkCore;
using ShopEZ_E_Commerce.API.Data;
using ShopEZ_E_Commerce.API.Models;

namespace ShopEZ_E_Commerce.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL 
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking() // improves performance for read-only
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();
        }

        // GET BY ID 
        public async Task<Product?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product id");

            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        // CREATE 
        public async Task<Product> AddAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        // UPDATE 
        public async Task<Product> UpdateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");

            var exists = await _context.Products
                .AnyAsync(p => p.ProductId == product.ProductId);

            if (!exists)
                throw new KeyNotFoundException($"Product with id {product.ProductId} not found");

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product id");

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        // EXISTS BY NAME 
        public async Task<bool> ExistsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required");

            name = name.Trim().ToLower();

            return await _context.Products
                .AnyAsync(p => p.Name.ToLower() == name);
        }
    }
}