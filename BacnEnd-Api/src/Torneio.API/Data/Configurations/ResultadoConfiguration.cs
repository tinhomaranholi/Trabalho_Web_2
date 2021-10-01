using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torneio.API.Models.Entities;

namespace Torneio.API.Data.Configurations
{
    public class ResultadoConfiguration : IEntityTypeConfiguration<Resultado>
    {
        public void Configure(EntityTypeBuilder<Resultado> builder)
        {
            builder.ToTable("Jogador");
            builder.HasKey(p => p.ResultadoId);
            //builder.Property(p => p.TimeVencedor).HasColumnType("VARCHAR(52)");
            builder.Property(p => p.DataOcorrencia).HasColumnType("Date");
        }
    }
}
