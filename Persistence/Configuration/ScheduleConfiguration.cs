using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");

            builder.Property(e => e.Day)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.Time)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");
        }
    }
}