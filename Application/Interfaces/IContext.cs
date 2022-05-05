using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IContext
    {
        public DbSet<Psicologo> Psicologos { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}