using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

namespace ShopEZ_E_Commerce.API.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid UserId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Total amount is required")]
        [Range(1, 10000000, ErrorMessage = "Total amount must be greater than 0")]
        public decimal TotalAmount { get; set; }

        //  Navigation Property
        public User User { get; set; }

        //  Order Items
        [Required(ErrorMessage = "Order must contain at least one item")]
        [MinLength(1, ErrorMessage = "Order must have at least one item")]
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}