using ShopEZ_E_Commerce.API.DTOs;
using ShopEZ_E_Commerce.API.Models;
using ShopEZ_E_Commerce.API.Repositories;

namespace ShopEZ_E_Commerce.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        // CREATE ORDER 
        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto)
        {
            ValidateOrder(dto);

            decimal totalAmount = 0;
            var orderItems = new List<OrderItem>();

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                if (product == null)
                    throw new KeyNotFoundException($"Product with id {item.ProductId} not found");

                if (product.Stock < item.Quantity)
                    throw new InvalidOperationException(
                        $"Only {product.Stock} items available for {product.Name}");

                // CALCULATE ITEM TOTAL
                decimal itemTotal = product.Price * item.Quantity;
                totalAmount += itemTotal;

                // UPDATE STOCK
                product.Stock -= item.Quantity;
                await _productRepo.UpdateAsync(product);

                // ADD ORDER ITEM
                orderItems.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            // APPLY BUSINESS LOGIC
            totalAmount = ApplyDiscount(totalAmount);
            totalAmount += ApplyDeliveryCharge(totalAmount);

            // CREATE ORDER
            var order = new Order
            {
                UserId = dto.UserId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount,
                OrderItems = orderItems
            };

            var createdOrder = await _orderRepo.CreateOrderAsync(order);

            return MapToResponse(createdOrder);
        }

        //  GET ALL
        public async Task<List<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            return orders.Select(MapToResponse).ToList();
        }

        //  GET BY ID 
        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid Order Id");

            var order = await _orderRepo.GetOrderByIdAsync(id);

            if (order == null)
                throw new KeyNotFoundException($"Order with id {id} not found");

            return MapToResponse(order);
        }

        //  GET BY USER 
        public async Task<List<OrderResponseDto>> GetOrdersByUserAsync(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid UserId");

            var orders = await _orderRepo.GetOrdersByUserAsync(userId);

            return orders.Select(MapToResponse).ToList();
        }

        //  VALIDATION 
        private void ValidateOrder(CreateOrderDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Order data is required");

            if (dto.UserId <= 0)
                throw new ArgumentException("Invalid UserId");

            if (dto.Items == null || !dto.Items.Any())
                throw new ArgumentException("Cart cannot be empty");

            // CHECK DUPLICATE PRODUCTS IN CART
            var duplicateProducts = dto.Items
                .GroupBy(i => i.ProductId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            if (duplicateProducts.Any())
                throw new InvalidOperationException("Duplicate products in cart are not allowed");

            foreach (var item in dto.Items)
            {
                if (item.ProductId <= 0)
                    throw new ArgumentException("Invalid ProductId");

                if (item.Quantity <= 0 || item.Quantity > 10)
                    throw new ArgumentException("Quantity must be between 1 and 10");
            }
        }

        //  BUSINESS LOGIC 
        private decimal ApplyDiscount(decimal total)
        {
            if (total >= 50000)
                return total - (total * 0.10m);

            if (total >= 20000)
                return total - (total * 0.05m);

            return total;
        }

        private decimal ApplyDeliveryCharge(decimal total)
        {
            return total < 20000 ? 200 : 50;
        }

        //  MAPPING 
        private OrderResponseDto MapToResponse(Order order)
        {
            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Items = order.OrderItems.Select(i => new OrderItemResponseDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product?.Name ?? "N/A",
                    Quantity = i.Quantity,
                    Price = i.Price,
                    Total = i.Quantity * i.Price
                }).ToList()
            };
        }
    }
}