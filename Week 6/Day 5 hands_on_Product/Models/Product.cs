<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Product
    {

        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Product Name should be between 5 and 15 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Category should be between 5 and 15 characters")]
        public string Category { get; set; }
    }
}
=======
﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Product
    {

        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Product Name should be between 5 and 15 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Category should be between 5 and 15 characters")]
        public string Category { get; set; }
    }
}
>>>>>>> 5e4ba3d69eecab8d2944084ab49d3ed4ddd91899
