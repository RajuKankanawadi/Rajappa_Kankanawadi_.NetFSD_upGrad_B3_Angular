using Microsoft.AspNetCore.Mvc;
using ShopEZ_E_Commerce.API.Models;
using ShopEZ_E_Commerce.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopEZ_E_Commerce.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //  CREATE USER 
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "User created successfully",
                data = user
            });
        }

        //  GET ALL USERS 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null || !users.Any())
            {
                return NotFound(new
                {
                    message = "No users found"
                });
            }

            return Ok(new
            {
                message = "Users fetched successfully",
                data = users
            });
        }
    }
}
