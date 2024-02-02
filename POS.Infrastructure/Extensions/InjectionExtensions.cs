using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Persistences.Contexts;

namespace POS.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        //Metodo de injection
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services, IConfiguration configuration) {

            var assenbly = typeof(POSContext).Assembly.FullName;

            services.AddDbContext<POSContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("POSConnection"), b => b.MigrationsAssembly(assenbly)), ServiceLifetime.Transient);

            return services;
        }
    }
}
