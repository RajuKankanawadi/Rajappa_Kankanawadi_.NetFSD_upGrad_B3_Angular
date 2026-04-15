using ShopEZ_E_Commerce.API.Models;

namespace ShopEZ_E_Commerce.API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);

        Task<List<Order>> GetAllOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task<List<Order>> GetOrdersByUserAsync(int userId);
    }
}