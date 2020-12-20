using Faces.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Faces.Persistence
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FacesDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("FacesConnection"),
                        b => b.MigrationsAssembly(typeof(FacesDbContext).Assembly.FullName)));

            services.AddScoped<IFacesDbContext>(provider => provider.GetService<FacesDbContext>());

            return services;
        }
    }
}
