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

        public DbSet<Psicologo> Psicologos { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

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
            modelBuilder.Entity<Psicologo>()
                .HasKey(e => e.PsicologoId)
                .HasName("pkPsicologo");

            modelBuilder.Entity<Agenda>()
                .HasKey(e => e.AgendaId)
                .HasName("pkAgenda");

            modelBuilder.Entity<Psicologo>()
                .HasMany(e => e.Agenda)
                .WithOne(e => e.Psicologo)
                .HasConstraintName("fkpsicologoAgendaId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}