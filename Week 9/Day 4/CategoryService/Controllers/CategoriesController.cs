using CategoryService.Models;
using CategoryService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService service;

    public CategoriesController(ICategoryService service)
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
    public async Task<IActionResult> Add(Category item)
    {
        return Ok(await service.Add(item));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Category item)
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