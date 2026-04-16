using ContactService.Models;

namespace ContactService.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task<Contact> Add(Contact c);
        Task Update(Contact c);
        Task Delete(int id);
    }
}