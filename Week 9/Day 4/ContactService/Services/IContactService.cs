using ContactService.Models;

namespace ContactService.Services;

public interface IContactService
{
    Task<List<Contact>> GetAll();
    Task<Contact> GetById(int id);
    Task<Contact> Add(Contact item);
    Task Update(Contact item);
    Task Delete(int id);
}