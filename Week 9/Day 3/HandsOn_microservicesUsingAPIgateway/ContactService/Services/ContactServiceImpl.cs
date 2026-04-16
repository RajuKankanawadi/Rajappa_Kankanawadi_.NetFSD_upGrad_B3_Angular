using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactServiceImpl : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactServiceImpl(IContactRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Contact>> GetAll() => _repo.GetAll();
        public Task<Contact> GetById(int id) => _repo.GetById(id);
        public Task<Contact> Add(Contact c) => _repo.Add(c);
        public Task Update(Contact c) => _repo.Update(c);
        public Task Delete(int id) => _repo.Delete(id);
    }
}