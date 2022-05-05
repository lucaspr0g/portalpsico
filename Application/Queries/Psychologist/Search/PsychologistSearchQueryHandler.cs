using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Psychologist.Search
{
    public class PsychologistSearchQueryHandler : IRequestHandler<PsychologistSearchQuery, List<Psicologo>>
    {
        private readonly IContext _context;

        public PsychologistSearchQueryHandler(IContext context)
        {
            _context = context;
        }

        public async Task<List<Psicologo>> Handle(PsychologistSearchQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Psicologos.Where(s => s.isActive);

            if (!string.IsNullOrWhiteSpace(request.PsicologoId))
                query = query.Where(s => s.PsicologoId == request.PsicologoId);

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(s => s.Nome.Contains(request.Name));

            if (!string.IsNullOrWhiteSpace(request.State))
                query = query.Where(s => s.Estado == request.State);

            var psicologos = query.ToList();

            return psicologos;
        }
    }
}