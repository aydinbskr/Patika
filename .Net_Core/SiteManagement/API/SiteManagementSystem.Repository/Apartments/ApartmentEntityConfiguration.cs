using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Apartments
{
    public class ApartmentEntityConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartments").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Block).HasColumnName("Block").IsRequired().HasMaxLength(100);
            builder.Property(b => b.Status).HasColumnName("Status").HasConversion<byte>().IsRequired();
            builder.Property(b => b.Type).HasColumnName("Type").HasConversion<byte>();
            builder.Property(b => b.Floor).HasColumnName("Floor");
            builder.Property(b => b.ApartmentNumber).HasColumnName("ApartmentNumber");
            builder.Property(b => b.OwnerOrTenant).HasColumnName("OwnerOrTenant");

          

           
        }
    }
}
