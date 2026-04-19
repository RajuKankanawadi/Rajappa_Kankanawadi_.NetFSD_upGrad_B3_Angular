using CategoryService.Models;

namespace CategoryService.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category item);
        Task Update(Category item);
        Task Delete(int id);
    }
}