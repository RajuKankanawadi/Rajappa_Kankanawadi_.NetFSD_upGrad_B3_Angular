using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;
using WebApplication14.Repositories;

namespace ContactManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repo;

    public ContactsController(IContactRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await _repo.GetByIdAsync(id);
        if (data == null)
            return NotFound();

        return Ok(data);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post(Contact contact)
    {
        await _repo.AddAsync(contact);
        return Ok(contact);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Contact contact)
    {
        await _repo.UpdateAsync(contact);
        return Ok(contact);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return Ok();
    }
}