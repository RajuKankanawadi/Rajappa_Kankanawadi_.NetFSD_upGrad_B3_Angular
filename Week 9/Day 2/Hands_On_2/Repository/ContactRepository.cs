
using Microsoft.EntityFrameworkCore;
using WebApplication13.Data;
using WebApplication13.Models;

namespace WebApplication13.Repository
{
        public class ContactRepository : IContactRepository
        {
            private readonly AppDbContext _context;

            public ContactRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<(List<Contact>, int)> GetContactsAsync(int pageNumber, int pageSize)
            {
                var totalRecords = await _context.Contacts.CountAsync();

                var contacts = await _context.Contacts
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (contacts, totalRecords);
            }
        }
    }

