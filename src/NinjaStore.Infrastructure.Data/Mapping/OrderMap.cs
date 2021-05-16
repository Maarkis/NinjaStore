using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Domain.Entities;
using System;

namespace NinjaStore.Infrastructure.Data.Mapping
{

    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(f => f.Id);

            builder.Property(c => c.Amount)
                .IsRequired();

            builder.Property(c => c.Discount)
                .IsRequired();

            builder.Property(c => c.Value)
                .IsRequired();

            builder.Property(c => c.PurchaseDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

        }
    }
}
