using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 60000, Category = "Electronics" },
            new Product { Id = 2, Name = "Mobile", Price = 20000, Category = "Electronics" },
            new Product { Id = 3, Name = "Shoes", Price = 3000, Category = "Fashion" },
            new Product { Id = 4, Name = "Watch", Price = 5000, Category = "Accessories" }
        };
        public IActionResult Index()
        {


            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

    }
}
