using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Models;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }

    public DbSet<Book> Books {get;set;}
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
}

