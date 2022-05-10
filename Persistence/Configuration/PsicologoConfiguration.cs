using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class PsicologoConfiguration : IEntityTypeConfiguration<Psicologo>
    {
        public void Configure(EntityTypeBuilder<Psicologo> builder)
        {
            builder.ToTable("Psicologo");

            builder.Property(e => e.PsicologoId)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(e => e.Nome)
                .HasMaxLength(256)
                .IsRequired()
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Senha)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(e => e.CRP)
                .HasMaxLength(6)
                .IsRequired()
                .HasColumnType("varchar(6)");

            builder.Property(e => e.Abordagem)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Descricao)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.isActive)
                .IsRequired();

            builder.Property(e => e.AprovadoEPSI)
                .IsRequired();
        }
    }
}