using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository repo;

    public CategoryService(ICategoryRepository repo)
    {
        this.repo = repo;
    }

    public async Task<List<Category>> GetAll()
    {
        return await repo.GetAll();
    }

    public async Task<Category> GetById(int id)
    {
        return await repo.GetById(id);
    }

    public async Task<Category> Add(Category item)
    {
        return await repo.Add(item);
    }

    public async Task Update(Category item)
    {
        await repo.Update(item);
    }

    public async Task Delete(int id)
    {
        await repo.Delete(id);
    }
}