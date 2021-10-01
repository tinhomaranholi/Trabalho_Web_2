using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torneio.API.Models.Entities;

namespace Torneio.API.Data.Configurations
{
    public class TimeConfiguration : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.ToTable("Time");
            builder.HasKey(p => p.TimeId);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(52)");
            //builder.Property(p => p.Jogadores).HasColumnType("VARCHAR(52)");
            builder.HasMany(m => m.Jogadores).WithOne(o => o.Time).HasForeignKey(fk => fk.TimeId);

            //builder.HasMany(p => p.CampeonatoTimes)
            //.WithOne(ct => ct.Time)
            //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
