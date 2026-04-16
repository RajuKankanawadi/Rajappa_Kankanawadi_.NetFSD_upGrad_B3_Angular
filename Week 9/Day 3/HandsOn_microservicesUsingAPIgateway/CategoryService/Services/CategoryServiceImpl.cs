using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryServiceImpl(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Category>> GetAll() => _repo.GetAll();
        public Task<Category> GetById(int id) => _repo.GetById(id);
        public Task<Category> Add(Category c) => _repo.Add(c);
        public Task Update(Category c) => _repo.Update(c);
        public Task Delete(int id) => _repo.Delete(id);
    }
}
