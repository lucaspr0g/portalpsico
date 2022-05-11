using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IContext
    {
        public DbSet<Psychologist> Psycologists { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<ScheduleBooking> ScheduleBookings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}