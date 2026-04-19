using CategoryService.Data;
using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CategoryDbContext db;

    public CategoryRepository(CategoryDbContext db)
    {
        this.db = db;
    }

    public async Task<List<Category>> GetAll()
    {
        return await db.Categories.ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await db.Categories.FindAsync(id);
    }

    public async Task<Category> Add(Category item)
    {
        db.Categories.Add(item);
        await db.SaveChangesAsync();
        return item;
    }

    public async Task Update(Category item)
    {
        db.Categories.Update(item);
        await db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var data = await db.Categories.FindAsync(id);
        if (data != null)
        {
            db.Categories.Remove(data);
            await db.SaveChangesAsync();
        }
    }
}