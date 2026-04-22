
using ContactMgmtWebAPI.Interfaces;
using ContactMgmtWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService service, ILogger<ContactsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching all contacts");
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _service.GetById(id);

            if (contact == null)
            {
                _logger.LogWarning("Contact not found with id {Id}", id);
                return NotFound("Contact not found");
            }

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest("Invalid data");

            var created = _service.Add(contact);

            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contact contact)
        {
            if (id != contact.Id)
                return BadRequest("ID mismatch");

            var updated = _service.Update(id, contact);

            if (!updated)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);

            if (!deleted)
                return NotFound("Contact not found");

            return Ok("Deleted successfully");
        }
    }
}