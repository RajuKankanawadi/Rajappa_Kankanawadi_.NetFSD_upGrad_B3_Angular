using System.ComponentModel.DataAnnotations;

namespace ShopEZ_E_Commerce.API.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
