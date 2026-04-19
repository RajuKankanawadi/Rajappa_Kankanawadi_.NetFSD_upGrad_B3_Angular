using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> opt) : base(opt) { }

    public DbSet<Contact> Contacts { get; set; }
}