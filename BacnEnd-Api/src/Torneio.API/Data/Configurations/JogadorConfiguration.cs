using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torneio.API.Models.Entities;

namespace Torneio.API.Data.Configurations
{
    public class JogadorConfiguration : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.ToTable("Jogador");
            builder.HasKey(ct => new { ct.JogadorId, ct.TimeId });
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(52)");
            //builder.Property(p => p.TimeId).HasColumnType("VARCHAR(52)");

        }
    }
}
