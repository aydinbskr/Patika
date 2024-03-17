using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Context
{
    public interface IAppDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Player> Players { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}
