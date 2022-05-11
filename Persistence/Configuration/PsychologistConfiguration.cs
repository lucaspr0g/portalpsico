using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class PsychologistConfiguration : IEntityTypeConfiguration<Psychologist>
    {
        public void Configure(EntityTypeBuilder<Psychologist> builder)
        {
            builder.ToTable("Psychologist");

            builder.Property(e => e.PsychologistId)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired()
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.State)
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(e => e.CRP)
                .HasMaxLength(6)
                .IsRequired()
                .HasColumnType("varchar(6)");

            builder.Property(e => e.Approach)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(e => e.isActive)
                .IsRequired();

            builder.Property(e => e.ApprovedEPSI)
                .IsRequired();
        }
    }
}