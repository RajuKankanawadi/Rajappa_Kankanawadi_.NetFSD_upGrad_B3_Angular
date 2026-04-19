using ContactService.Models;
using ContactService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService service;

    public ContactsController(IContactService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await service.GetById(id);
        if (data == null) return NotFound();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Contact item)
    {
        return Ok(await service.Add(item));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Contact item)
    {
        await service.Update(item);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await service.Delete(id);
        return Ok();
    }
}