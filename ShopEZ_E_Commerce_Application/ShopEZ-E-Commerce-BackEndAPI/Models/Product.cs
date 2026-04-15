using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopEZ_E_Commerce.API.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1,000,000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [RegularExpression(@"^images\/[a-zA-Z0-9_-]+\.(jpg|jpeg|png|webp)$",
            ErrorMessage = "Image must be in format: images/p1.jpg")]
        public string ImageUrl { get; set; } = string.Empty;

        [Range(0, 1000, ErrorMessage = "Stock must be between 0 and 1000")]
        public int Stock { get; set; }

        //  Navigation Property
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}