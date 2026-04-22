using System.ComponentModel.DataAnnotations;

namespace ShopEZ_E_Commerce.API.DTOs
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "UserId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid UserId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Items are required")]
        [MinLength(1, ErrorMessage = "At least one item required")]
        public List<OrderItemDto> Items { get; set; } = new(); // Items can still be null -> can cause runtime issue
    }
}
