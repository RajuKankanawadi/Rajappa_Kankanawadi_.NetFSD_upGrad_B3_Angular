using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.DataAccess;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactInfo>>> GetAllContacts()
        {
            var contacts = await _repository.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> GetContactById(int id)
        {
            var contact = await _repository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<ContactInfo>> AddContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdContact = await _repository.AddContactAsync(contact);

            return Ok(new { contact, status = "New Contact successfully added to server..!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _repository.UpdateContactAsync(id, contact);

            if (!updated)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            return Ok($"Contact with ID {id} updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var deleted = await _repository.DeleteContactAsync(id);

            if (!deleted)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            return Ok($"Contact with ID {id} deleted successfully.");
        }
    }
}
