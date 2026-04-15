
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Repository;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts(
            int pageNumber = 1,
            int pageSize = 5)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 5;

            var (contacts, totalRecords) = await _repo.GetContactsAsync(pageNumber, pageSize);

            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new
            {
                totalRecords,
                totalPages,
                currentPage = pageNumber,
                pageSize,
                data = contacts
            };

            return Ok(response);
        }
    }
}