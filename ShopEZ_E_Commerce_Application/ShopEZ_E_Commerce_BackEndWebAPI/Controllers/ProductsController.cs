using Microsoft.AspNetCore.Mvc;
using ShopEZ_E_Commerce.API.DTOs;
using ShopEZ_E_Commerce.API.Services;

namespace ShopEZ_E_Commerce.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET ALL 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllProducts();

            return Ok(new
            {
                success = true,
                message = "Products fetched successfully",
                data = products
            });
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid product id"
                });

            var product = await _service.GetProductById(id);

            return Ok(new
            {
                success = true,
                message = $"Product with id {id} fetched successfully",
                data = product
            });
        }

        // CREATE PRODUCT 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid input",
                    errors = ModelState
                });

            var created = await _service.Create(dto);

            return Ok(new
            {
                success = true,
                message = $"Product {created.ProductId} created successfully",
                data = created
            });
        }
        // UPDATE PRODUCT 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateProductDto dto)
        {
            if (id <= 0)
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid product id"
                });

            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid input",
                    errors = ModelState
                });

            var updated = await _service.UpdateProduct(id, dto);

            return Ok(new
            {
                success = true,
                message = $"Product {id} updated successfully",
                data = updated
            });
        }

        // DELETE PRODUCT 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid product id"
                });

            await _service.DeleteProduct(id);

            return Ok(new
            {
                success = true,
                message = $"Product {id} deleted successfully"
            });
        }
    }
}