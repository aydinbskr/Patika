using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using SiteManagementSystem.Repository.Apartments;

namespace SiteManagementSystem.Repository.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.FullName).HasColumnName("FullName").IsRequired().HasMaxLength(100);
            builder.Property(b => b.NationalId).HasColumnName("NationalId").IsRequired();
            builder.Property(b => b.Email).HasColumnName("Email");
            builder.Property(b => b.Phone).HasColumnName("Phone");
            builder.Property(b => b.UserType).HasColumnName("UserType");

           

            builder.HasMany(b => b.Payments);

            builder.HasOne(a => a.Apartment)
                .WithOne(b => b.User)
                .HasForeignKey<Apartment>(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
