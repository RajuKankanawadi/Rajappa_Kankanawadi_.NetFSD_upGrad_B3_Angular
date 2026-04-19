using CategoryService.Models;

namespace CategoryService.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category item);
        Task Update(Category item);
        Task Delete(int id);
    }
}