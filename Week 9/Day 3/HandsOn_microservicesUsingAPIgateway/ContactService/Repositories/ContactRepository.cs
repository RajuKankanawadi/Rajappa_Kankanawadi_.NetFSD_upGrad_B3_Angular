using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAll() =>
            await _context.Contacts.ToListAsync();

        public async Task<Contact> GetById(int id) =>
            await _context.Contacts.FindAsync(id);

        public async Task<Contact> Add(Contact c)
        {
            _context.Contacts.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task Update(Contact c)
        {
            _context.Contacts.Update(c);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}