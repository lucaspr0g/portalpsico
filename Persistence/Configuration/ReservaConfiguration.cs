using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class ReservaConfiguration : IEntityTypeConfiguration<ScheduleBooking>
    {
        public void Configure(EntityTypeBuilder<ScheduleBooking> builder)
        {
            builder.ToTable("Reserva");

            builder.Property(e => e.Date)
                .IsRequired();
        }
    }
}