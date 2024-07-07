using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Payments
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.PaymentMethod).HasColumnName("PaymentMethod").IsRequired().HasMaxLength(100);
            builder.Property(b => b.PaymentDate).HasColumnName("PaymentDate").IsRequired();
            builder.Property(b => b.PaymentType).HasColumnName("PaymentType");
            builder.Property(b => b.Amount).HasColumnName("Amount");
            builder.Property(b => b.Year).HasColumnName("Year");
            builder.Property(b => b.Month).HasColumnName("Month");
            builder.Property(b => b.ApartmentId).HasColumnName("ApartmentId");
            builder.Property(b => b.UserId).HasColumnName("UserId");

            builder.HasOne(b => b.Apartment);
            builder.HasOne(b => b.User);
            builder.HasOne(b => b.Bill);

           

          
        }
    }
}
