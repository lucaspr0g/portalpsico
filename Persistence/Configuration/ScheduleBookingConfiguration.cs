using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class ScheduleBookingConfiguration : IEntityTypeConfiguration<ScheduleBooking>
    {
        public void Configure(EntityTypeBuilder<ScheduleBooking> builder)
        {
            builder.ToTable("ScheduleBooking");

            builder.Property(e => e.Date)
                .IsRequired();
        }
    }
}