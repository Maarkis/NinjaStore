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

            //serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //serviceCollection.AddScoped<IUserRepository, UserRepository>();
            //serviceCollection.AddScoped<IClientRepository, ClientRepository>();
            //serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //serviceCollection.AddScoped<ICompanyRepository, CompanyRepository>();
            //serviceCollection.AddScoped<IServiceRepository, ServiceRepository>();
            //serviceCollection.AddScoped<IServiceEmployeeRepository, ServiceEmployeeRepository>();
            //serviceCollection.AddScoped<IPolicyRepository, PolicyRepository>();
            //serviceCollection.AddScoped<ISchedulingRepository, SchedulingRepository>();
            //serviceCollection.AddScoped<ILocationRepository, LocationRepository>();
            //serviceCollection.AddScoped<IEmployeeWorkHoursRepository, EmployeeWorkHoursRepository>();
            //serviceCollection.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
        }
    }
}
