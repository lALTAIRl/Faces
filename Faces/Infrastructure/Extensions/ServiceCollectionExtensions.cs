using Faces.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faces.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAndValidateApplicationSettings<FacePlusPlusSettings>(configuration);

            return services;
        }

        internal static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("FacePlusPlus", client =>
            {
                client.BaseAddress = new Uri(configuration["FacePlusPlusSettings:Url"]);
            });

            return services;
        }

        internal static IServiceCollection ConfigureAndValidateApplicationSettings<T>(
            this IServiceCollection @this,
            IConfiguration configuration) where T : class, IApplicationSettings
            => @this.Configure<T>(configuration.GetSection(typeof(T).Name))
                    .PostConfigure<T>(settings =>
                    {
                        var configurationErrors = settings.ValidateApplicationSettings().ToArray();
                        if (configurationErrors.Any())
                        {
                            var aggregatedErrors = string.Join("\n", configurationErrors);
                            throw new ApplicationException(
                                $"Found {configurationErrors.Length} configuration error(s) in {typeof(T).Name}:\n{aggregatedErrors}");
                        }
                    });
    }
}
