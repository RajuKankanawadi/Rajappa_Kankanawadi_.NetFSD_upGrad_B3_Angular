using ShopEZ_E_Commerce.API.DTOs;
using ShopEZ_E_Commerce.API.Models;
using ShopEZ_E_Commerce.API.Repositories;

namespace ShopEZ_E_Commerce.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET ALL 
        public async Task<IEnumerable<ProductResponseDto>> GetAllProducts()
        {
            var products = await _repo.GetAllAsync();

            return products.Select(p => MapToDto(p));
        }

        // GET BY ID 
        public async Task<ProductResponseDto> GetProductById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product id");

            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException($"Product with id {id} not found");

            return MapToDto(product);
        }

        // CREATE 
        public async Task<ProductResponseDto> Create(CreateProductDto dto)
        {
            ValidateProduct(dto);

            // CHECK DUPLICATE NAME (CASE-INSENSITIVE)
            if (await _repo.ExistsByName(dto.Name.Trim()))
                throw new InvalidOperationException("Product already exists with same name");

            var product = new Product
            {
                Name = dto.Name.Trim(),
                Description = dto.Description.Trim(),
                Price = dto.Price,
                ImageUrl = dto.ImageUrl.Trim(),
                Stock = dto.Stock
            };

            await _repo.AddAsync(product);

            return MapToDto(product);
        }

        // UPDATE 
        public async Task<ProductResponseDto> UpdateProduct(int id, CreateProductDto dto)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product id");

            ValidateProduct(dto);

            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException($"Product with id {id} not found");

            // CHECK DUPLICATE NAME (EXCLUDING SAME PRODUCT)
            if (!existing.Name.Equals(dto.Name.Trim(), StringComparison.OrdinalIgnoreCase)
                && await _repo.ExistsByName(dto.Name.Trim()))
            {
                throw new InvalidOperationException("Another product with same name exists");
            }

            existing.Name = dto.Name.Trim();
            existing.Description = dto.Description.Trim();
            existing.Price = dto.Price;
            existing.ImageUrl = dto.ImageUrl.Trim();
            existing.Stock = dto.Stock;

            await _repo.UpdateAsync(existing);

            return MapToDto(existing);
        }

        // DELETE 
        public async Task<bool> DeleteProduct(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product id");

            var exists = await _repo.GetByIdAsync(id);

            if (exists == null)
                throw new KeyNotFoundException($"Product with id {id} not found");

            return await _repo.DeleteAsync(id);
        }

        // COMMON VALIDATION 
        private void ValidateProduct(CreateProductDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Product data is required");

            if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Trim().Length < 3)
                throw new ArgumentException("Product name must be at least 3 characters");

            if (dto.Name.Length > 100)
                throw new ArgumentException("Product name cannot exceed 100 characters");

            if (string.IsNullOrWhiteSpace(dto.Description) || dto.Description.Trim().Length < 10)
                throw new ArgumentException("Description must be at least 10 characters");

            if (dto.Price <= 0 || dto.Price > 1000000)
                throw new ArgumentException("Price must be between 1 and 1,000,000");

            if (dto.Stock < 0 || dto.Stock > 1000)
                throw new ArgumentException("Stock must be between 0 and 1000");

            if (string.IsNullOrWhiteSpace(dto.ImageUrl))
                throw new ArgumentException("Image URL is required");

            if (!dto.ImageUrl.StartsWith("images/"))
                throw new ArgumentException("Image must be in 'images/filename.jpg' format");
        }

        // MAPPING 
        private ProductResponseDto MapToDto(Product p)
        {
            return new ProductResponseDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock
            };
        }
    }
}
