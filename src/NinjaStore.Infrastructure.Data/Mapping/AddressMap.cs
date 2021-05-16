using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Domain.Entities;

namespace NinjaStore.Infrastructure.Data.Mapping
{

    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(address => address.Id);

            builder.HasOne(address => address.Client)
                .WithMany(client => client.Addresses)
                .HasForeignKey(client => client.Id);

            builder.Property(address => address.Name)
                .IsRequired();
            builder.Property(address => address.Cep)
                .IsRequired();

            builder.Property(address => address.Complement);

            builder.Property(address => address.District)
                .IsRequired();

            builder.Property(address => address.City)
                .IsRequired();

            builder.Property(address => address.State)
                .IsRequired();

            builder.Property(address => address.Number)
                .IsRequired();
        }
    }
}
