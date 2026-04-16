using Microsoft.AspNetCore.Mvc;
using CategoryService.Services;
using CategoryService.Models;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Category c) => Ok(await _service.Add(c));

    [HttpPut]
    public async Task<IActionResult> Update(Category c)
    {
        await _service.Update(c);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }
}
