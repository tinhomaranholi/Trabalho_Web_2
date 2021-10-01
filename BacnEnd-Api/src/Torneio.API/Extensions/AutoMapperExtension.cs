using Microsoft.Extensions.DependencyInjection;

namespace Torneio.API.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));

            return services;
        }
    }
}
