using CategoryService.Models;

namespace CategoryService.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category c);
        Task Update(Category c);
        Task Delete(int id);
    }
}