using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Domain.Entities;
using System;

namespace NinjaStore.Infrastructure.Data.Mapping
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Order).WithMany(s => s.Products).HasForeignKey(s => s.OrderId);

            builder.HasOne(s => s.Product).WithMany(s => s.Orders).HasForeignKey(s => s.ProductId);


            //builder.HasOne(s => s.Order).WithMany(s => s.Products).HasForeignKey(s => s.OrderId).HasPrincipalKey(s => s.Id);

            //builder.Property<int>("Id");
            //builder.HasOne(s => s.Product).WithMany(s => s.Orders).HasForeignKey("Id").HasPrincipalKey(x => x.Id);
        }
    }
}
