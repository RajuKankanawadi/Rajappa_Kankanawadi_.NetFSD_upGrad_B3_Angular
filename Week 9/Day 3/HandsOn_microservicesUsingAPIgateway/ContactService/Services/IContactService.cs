using ContactService.Models;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task<Contact> Add(Contact c);
        Task Update(Contact c);
        Task Delete(int id);
    }
}