using WebApplication14.Models;

namespace WebApplication14.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(int id);
}
