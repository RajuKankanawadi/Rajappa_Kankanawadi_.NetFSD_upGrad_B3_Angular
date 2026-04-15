using Microsoft.AspNetCore.Mvc;
using ShopEZ_E_Commerce.API.DTOs;
using ShopEZ_E_Commerce.API.Services;

namespace ShopEZ_E_Commerce.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        // CREATE ORDER 
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid input",
                    errors = ModelState
                });

            var order = await _service.CreateOrderAsync(dto);

            return Ok(new
            {
                success = true,
                message = "Order placed successfully",
                data = order
            });
        }

        // GET ALL 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllOrdersAsync();

            return Ok(new
            {
                success = true,
                message = "Orders fetched successfully",
                data = orders
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
                    message = "Invalid order id"
                });

            var order = await _service.GetOrderByIdAsync(id);

            return Ok(new
            {
                success = true,
                message = $"Order with id {id} fetched successfully",
                data = order
            });
        }
    }
}