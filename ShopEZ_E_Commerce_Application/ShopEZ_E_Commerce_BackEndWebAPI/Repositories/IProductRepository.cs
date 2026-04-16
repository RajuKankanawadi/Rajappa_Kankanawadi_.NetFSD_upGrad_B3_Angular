using ShopEZ_E_Commerce.API.Models;

namespace ShopEZ_E_Commerce.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> AddAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsByName(string name);
    }
}