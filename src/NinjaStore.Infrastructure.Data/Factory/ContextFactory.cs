using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NinjaStore.Infrastructure.Data.Context;

namespace NinjaStore.Infrastructure.Data.Factory
{
    public class ContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=NinjaStore;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
