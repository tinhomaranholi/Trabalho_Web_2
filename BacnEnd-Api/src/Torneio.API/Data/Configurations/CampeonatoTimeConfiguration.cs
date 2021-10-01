using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torneio.API.Models.Entities;

namespace Torneio.API.Data.Configurations
{
    public class CampeonatoTimeConfigurations : IEntityTypeConfiguration<CampeonatoTime>
    {
        public void Configure(EntityTypeBuilder<CampeonatoTime> builder)
        {
            builder.ToTable("CampeonatoTime");
            builder.HasKey(ct => new { ct.CampeonatoId, ct.TimeId});
            //builder.Property(p => p.Time).HasColumnType("VARCHAR(52)");
            //builder.Property(p => p.Campeonato).HasColumnType("VARCHAR(52)");
        }
    }
}
