using Faces.Application.Interfaces;
using Faces.FacePlusPlus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Faces.FacePlusPlus
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddFacePlusPlus(this IServiceCollection services)
        {
            services.AddTransient<IFacePlusPlusService, FacePlusPlusService>();

            return services;
        }
    }
}
