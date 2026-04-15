using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Services;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _service.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetContactById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
    }
}
