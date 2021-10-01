using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Torneio.API.Contexts;
using Torneio.API.Models.Entities;

namespace Torneio.API.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services)
        {
            services.AddDbContext<TorneioContext>(opt => opt.UseInMemoryDatabase("TorneioDB"));
            return services;
        }

        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TorneioContext>();
            var usuario = new Usuario
            {
                Email = "tinho@maranholi.com",
                CreatedAt = DateTime.Now,
                //JogadorId = Guid.NewGuid(),
                Nome = "Victor Maranholi",
                Role = Models.TipoUsuario.COMUM,
                Senha = "12345678",
                UsuarioId = Guid.NewGuid()
            };

            context.AddRange(usuario);

            context.SaveChanges();

        }
    }
}
