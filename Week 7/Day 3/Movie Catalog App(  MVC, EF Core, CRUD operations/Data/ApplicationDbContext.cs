using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}
