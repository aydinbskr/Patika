using SiteManagementSystem.Repository.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Repository.Payments;
using SiteManagementSystem.Repository.Bills;

namespace SiteManagementSystem.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Bill> Bills { get; set; }
       

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bill>()
            .HasOne(b => b.Payment)
            .WithOne(p => p.Bill)
            .HasForeignKey<Payment>(p => p.Id); // Payment tablosundaki Id, Bill tablosundaki Id ile eşleşiyor

            // Diğer yapılandırmalar
            //modelBuilder.Entity<Payment>()
            //    .HasOne(p => p.Apartment)
            //    .WithMany(a => a.Payment)
            //    .HasForeignKey(p => p.ApartmentId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId);


        }
    }
}
