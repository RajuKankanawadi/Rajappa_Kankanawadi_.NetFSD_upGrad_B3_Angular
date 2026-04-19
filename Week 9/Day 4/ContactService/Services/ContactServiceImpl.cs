using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository repo;

    public ContactService(IContactRepository repo)
    {
        this.repo = repo;
    }

    public async Task<List<Contact>> GetAll()
    {
        return await repo.GetAll();
    }

    public async Task<Contact> GetById(int id)
    {
        return await repo.GetById(id);
    }

    public async Task<Contact> Add(Contact item)
    {
        return await repo.Add(item);
    }

    public async Task Update(Contact item)
    {
        await repo.Update(item);
    }

    public async Task Delete(int id)
    {
        await repo.Delete(id);
    }
}