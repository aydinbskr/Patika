using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public interface IAppDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }

        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
