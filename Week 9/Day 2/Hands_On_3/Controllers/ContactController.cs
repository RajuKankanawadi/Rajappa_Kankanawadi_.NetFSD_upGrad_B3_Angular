using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Data;
using Microsoft.AspNetCore.RateLimiting;

namespace WebApplication13.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    [EnableRateLimiting("fixed")] 
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }
    }
}