using Microsoft.EntityFrameworkCore;
using NinjaStore.Domain.Entities;
using NinjaStore.Infrastructure.Data.Mapping;

namespace NinjaStore.Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(new ClientMap().Configure);
            modelBuilder.Entity<Address>(new AddressMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Order>(new OrderMap().Configure);
            modelBuilder.Entity<OrderProduct>(new OrderProductMap().Configure);

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        

    }
}

