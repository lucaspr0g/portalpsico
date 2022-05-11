using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class Context : DbContext, IContext
    {
        private readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Psychologist> Psycologists { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<ScheduleBooking> ScheduleBookings { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.ModifiedOn = entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("PortalDataBase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Psychologist>()
                .HasKey(e => e.PsychologistId)
                .HasName("pkPsicologo");

            modelBuilder.Entity<Schedule>()
                .HasKey(e => e.ScheduleId)
                .HasName("pkAgenda");

            modelBuilder.Entity<ScheduleBooking>()
                .HasKey(e => e.BookingId)
                .HasName("pkReserva");

            modelBuilder.Entity<Psychologist>()
                .HasMany(e => e.Schedules)
                .WithOne(e => e.Psychologist)
                .HasConstraintName("fkpsicologoAgendaId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Psychologist>()
                .HasMany(e => e.ScheduleBookings)
                .WithOne(e => e.Psycologist)
                .HasConstraintName("fkpsicologoReservaId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}