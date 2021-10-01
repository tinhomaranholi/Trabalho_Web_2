using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Torneio.API.Models.Entities;
using Microsoft.Extensions.Logging;

namespace Torneio.API.Contexts
{
    public class TorneioContext : DbContext
    {
        public TorneioContext(DbContextOptions<TorneioContext> options) : base(options)
        {
        }

        public TorneioContext()
        {
        }

        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<CampeonatoTime> CampeonatoTimes { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TorneioContext).Assembly);
            MapearPropriedadesEsquecidas(modelBuilder);
        }

        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            //AdicionaProvisorio(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        property.SetMaxLength(100);
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }

        //protected void AdicionaProvisorio(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Time>(builder =>
        //    {
        //        builder.HasKey(o => o.TimeId);
        //        builder.HasMany(m => m.Jogadores).WithOne(o => o.Time).HasForeignKey(fk => fk.TimeId);
        //    });

        //    modelBuilder.Entity<Jogador>(builder =>
        //    {
        //        builder.HasKey(o => o.JogadorId);
        //    });

        //    modelBuilder.Entity<CampeonatoTime>().HasKey(ct => new { ct.CampeonatoId, ct.TimeId });


        //}

       
    }
}
