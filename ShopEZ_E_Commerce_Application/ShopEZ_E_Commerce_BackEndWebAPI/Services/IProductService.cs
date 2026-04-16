using ShopEZ_E_Commerce.API.DTOs;

namespace ShopEZ_E_Commerce.API.Services
{
    public interface IProductService
    {
        // GET ALL
        Task<IEnumerable<ProductResponseDto>> GetAllProducts();

        // GET BY ID
        Task<ProductResponseDto> GetProductById(int id);

        // CREATE
        Task<ProductResponseDto> Create(CreateProductDto dto);

        // UPDATE
        Task<ProductResponseDto> UpdateProduct(int id, CreateProductDto dto);

        // DELETE
        Task<bool> DeleteProduct(int id);
    }
}