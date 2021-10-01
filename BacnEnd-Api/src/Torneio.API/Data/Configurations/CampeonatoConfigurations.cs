using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torneio.API.Models.Entities;

namespace Torneio.API.Data.Configurations
{
    public class CampeonatoConfigurations : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.ToTable("Campeonato");
            builder.HasKey(p => p.CampeonatoId);
            builder.Property(p => p.Titulo).HasColumnType("VARCHAR(52)");

            //builder.HasMany(p => p.CampeonatoTimes)
            //.WithOne(ct => ct.Campeonato)
            //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}

