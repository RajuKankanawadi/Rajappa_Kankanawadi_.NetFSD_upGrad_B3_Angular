using Microsoft.AspNetCore.Mvc;
using ContactService.Services;
using ContactService.Models;

[ApiController]
[Route("api/contacts")]
public class ContactController : ControllerBase
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await _service.GetById(id);
        if (contact == null) return NotFound();
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Contact c) =>
        Ok(await _service.Add(c));

    [HttpPut]
    public async Task<IActionResult> Update(Contact c)
    {
        await _service.Update(c);
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok("Deleted");
    }
}