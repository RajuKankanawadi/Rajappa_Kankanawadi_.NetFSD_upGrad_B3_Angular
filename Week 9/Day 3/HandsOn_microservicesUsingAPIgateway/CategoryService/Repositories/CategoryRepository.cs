using CategoryService.Data;
using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll() =>
            await _context.Categories.ToListAsync();

        public async Task<Category> GetById(int id) =>
            await _context.Categories.FindAsync(id);

        public async Task<Category> Add(Category c)
        {
            _context.Categories.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task Update(Category c)
        {
            _context.Categories.Update(c);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c != null)
            {
                _context.Categories.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}
