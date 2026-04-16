using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShopEZ_E_Commerce.API.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "OrderId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid OrderId")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid ProductId")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //  ORDER RELATION
        [ForeignKey("OrderId")]
        [JsonIgnore]
        public Order Order { get; set; } = null!;

        //  PRODUCT RELATION
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
    }
}