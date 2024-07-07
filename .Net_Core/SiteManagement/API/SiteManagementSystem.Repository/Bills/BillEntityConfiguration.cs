using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Bills
{
    public class BillEntityConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.ApartmentId).HasColumnName("ApartmentId").IsRequired().HasMaxLength(100);
            builder.Property(b => b.Amount).HasColumnName("Amount").IsRequired();
            builder.Property(b => b.Type).HasColumnName("Type");
            builder.Property(b => b.DueDate).HasColumnName("DueDate");
            builder.Property(b => b.IsPaid).HasColumnName("IsPaid");

         

            builder.HasOne(b => b.Payment);

           
        }
    }
}
