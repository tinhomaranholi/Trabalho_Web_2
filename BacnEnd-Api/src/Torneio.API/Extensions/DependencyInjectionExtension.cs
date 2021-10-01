using Microsoft.Extensions.DependencyInjection;
using Torneio.API.Contexts;
using Torneio.API.Interfaces;
using Torneio.API.Interfaces.Services;
using Torneio.API.Repositories;
using Torneio.API.Services;

namespace Torneio.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection InitializeDependencies(this IServiceCollection services)
        {
            services.AddScoped<TorneioContext>();
            services.AddScoped<ITimeRepository, TimeRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
