using System.ComponentModel.DataAnnotations;

namespace ShopEZ_E_Commerce.API.DTOs
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public List<OrderItemResponseDto> Items { get; set; } = new();
    }
}