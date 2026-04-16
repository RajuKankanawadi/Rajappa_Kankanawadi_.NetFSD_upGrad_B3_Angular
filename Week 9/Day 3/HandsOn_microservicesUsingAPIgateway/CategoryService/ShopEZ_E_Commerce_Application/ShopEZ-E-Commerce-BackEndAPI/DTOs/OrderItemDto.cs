using System.ComponentModel.DataAnnotations;

namespace ShopEZ_E_Commerce.API.DTOs
{
    public class OrderItemDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Invalid ProductId")]
        public int ProductId { get; set; }

        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public int Quantity { get; set; }
    }
}