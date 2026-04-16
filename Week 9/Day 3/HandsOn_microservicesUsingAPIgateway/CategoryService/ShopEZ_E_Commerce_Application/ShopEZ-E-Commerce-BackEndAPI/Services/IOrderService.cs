using ShopEZ_E_Commerce.API.DTOs;
using ShopEZ_E_Commerce.API.Models;

namespace ShopEZ_E_Commerce.API.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto);

        Task<List<OrderResponseDto>> GetAllOrdersAsync();

        Task<OrderResponseDto> GetOrderByIdAsync(int id);

        Task<List<OrderResponseDto>> GetOrdersByUserAsync(int userId);



    }
}
