using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactDbContext db;

    public ContactRepository(ContactDbContext db)
    {
        this.db = db;
    }

    public async Task<List<Contact>> GetAll()
    {
        return await db.Contacts.ToListAsync();
    }

    public async Task<Contact> GetById(int id)
    {
        return await db.Contacts.FindAsync(id);
    }

    public async Task<Contact> Add(Contact item)
    {
        db.Contacts.Add(item);
        await db.SaveChangesAsync();
        return item;
    }

    public async Task Update(Contact item)
    {
        db.Contacts.Update(item);
        await db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var data = await db.Contacts.FindAsync(id);
        if (data != null)
        {
            db.Contacts.Remove(data);
            await db.SaveChangesAsync();
        }
    }
}