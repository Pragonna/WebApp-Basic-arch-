using Core.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistence
{
    public static class PersistenceServicesRegistration
    {
            const string SQL = "Sql";
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<EFDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString(SQL));
            });

            return services;
        }
    }
}
