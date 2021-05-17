using Microsoft.Extensions.DependencyInjection;
using NinjaStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace NinjaStore.Infrastructure.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
