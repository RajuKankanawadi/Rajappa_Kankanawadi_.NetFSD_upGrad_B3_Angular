using Microsoft.EntityFrameworkCore;
using ShopEZ_E_Commerce.API.Data;
using ShopEZ_E_Commerce.API.Models;

namespace ShopEZ_E_Commerce.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE ORDER 
        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null");

            if (order.OrderItems == null || !order.OrderItems.Any())
                throw new ArgumentException("Order must contain at least one item");

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        // GET ALL ORDERS 
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .AsNoTracking() // improves performance (read-only)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrderDate) // latest first
                .ToListAsync();
        }

        // GET ORDER BY ID 
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid Order Id");

            return await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        // GET ORDERS BY USER 
        public async Task<List<Order>> GetOrdersByUserAsync(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid UserId");

            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}