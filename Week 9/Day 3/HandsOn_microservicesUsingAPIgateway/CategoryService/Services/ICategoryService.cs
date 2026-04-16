using CategoryService.Models;

namespace CategoryService.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category c);
        Task Update(Category c);
        Task Delete(int id);
    }
}