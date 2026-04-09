using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> products = new List<Product>()   {
        new Product { Id = 1, Name = "Laptop", Category= "Electronics", Price = 65000 },
        new Product { Id = 2, Name = "Mobile", Category= "Electronics", Price = 30000 },
        new Product { Id = 3, Name = "Tablet", Category= "Electronics", Price = 45000 },
    };

        // SHOW ALL PRODUCTS
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

       // SHOW PRODUCT WHERE PRODUCT ID = ENTER ID 
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.Find(item => item.Id == id);

            if (product == null)
            {
                return NotFound("Requested product does not exists");
            }
            else
            {
                return Ok(product);
            }
        }

        // ADD PRODUCT 

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);

            // Customize the response :  data, status codes 
            return Ok(new { product, status = "New product successfully added to server..!" });
        }

        // UPDATE PRODUCT WHERE OLD PRODUCT ID = NEW PRODUCT ID

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var oldProduct = products.Find(item => item.Id == id);

            if (oldProduct == null)
            {
                return NotFound("Requested product does not exists");
            }
            else
            {
                oldProduct.Name = product.Name;
                oldProduct.Category = product.Category;
                oldProduct.Price = product.Price;
                return Ok(new { updatedProduct = oldProduct, status = "Product details are updated successfully in server..!" });
            }
        }

        // DELETE PRODUCT WHERE PRODUCT ID = ENTER ID

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.Find(item => item.Id == id);

            if (product == null)
            {
                return NotFound("Requested product does not exists");
            }
            else
            {
                products.Remove(product);
                return Ok(new { product, status = "Product details are deleted successfully in server..!" });
            }
        }
    }
}

