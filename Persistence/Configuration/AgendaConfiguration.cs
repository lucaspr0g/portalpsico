using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");

            builder.Property(e => e.Domingo)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.Segunda)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.Terça)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.Quarta)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.Quinta)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.Sexta)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.Sabado)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");
        }
    }
}