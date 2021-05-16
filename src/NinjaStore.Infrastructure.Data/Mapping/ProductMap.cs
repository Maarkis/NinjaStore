using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Domain.Entities;

namespace NinjaStore.Infrastructure.Data.Mapping
{

    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Description)
                .IsRequired();

            builder.Property(product => product.Value)                
                .IsRequired();

            builder.Property(product => product.Photo);
        }
    }
}
