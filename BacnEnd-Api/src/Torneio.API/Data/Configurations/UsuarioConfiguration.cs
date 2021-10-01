using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torneio.API.Models.Entities;

namespace Torneio.API.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(ct => ct.UsuarioId);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(52)");
            builder.Property(p => p.Email).HasColumnType("VARCHAR(52)");
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(52)");
            builder.Property(p => p.Role).HasConversion<int>();
            //builder.
        }
    }
}
