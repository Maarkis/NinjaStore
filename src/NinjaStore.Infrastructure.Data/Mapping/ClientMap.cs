using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Domain.Entities;

namespace NinjaStore.Infrastructure.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(client => client.Id);   
            
            builder.Property(client => client.Name)                
                .IsRequired()
                .HasMaxLength(60);

            builder.HasIndex(client => client.Email)
                .IsUnique();               
        }
    }
}
