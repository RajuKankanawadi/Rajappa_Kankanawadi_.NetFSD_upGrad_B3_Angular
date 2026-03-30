using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{

    public class ProductsController : Controller
    {
        // Temporary product list
        public static List<Product> products = new List<Product>()
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 50000, Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Mobile", Price = 20000, Category = "Gadgets" },
            new Product { ProductId = 3, ProductName = "Headphone", Price = 3000, Category = "Audio" }
        };

        // Display all products
        public IActionResult Index()
        {
            return View(products);
        }
        // Display details of a single product
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }
        // GET: Create Product
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }
        // GET: Edit Product
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }
        // POST: Edit Product
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);

                if (product != null)
                {
                    product.ProductName = updatedProduct.ProductName;
                    product.Price = updatedProduct.Price;
                    product.Category = updatedProduct.Category;
                }

                return RedirectToAction("Index");
            }

            return View(updatedProduct);
        }
        // GET: Delete Product
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        // POST: Delete Product
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }








    }
}
