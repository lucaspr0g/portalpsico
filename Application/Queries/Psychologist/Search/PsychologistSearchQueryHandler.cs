using Application.Interfaces;
using MediatR;

namespace Application.Queries.Psychologist.Search
{
    public class PsychologistSearchQueryHandler : IRequestHandler<PsychologistSearchQuery, List<Domain.Entities.Psychologist>>
    {
        private readonly IContext _context;

        public PsychologistSearchQueryHandler(IContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Psychologist>> Handle(PsychologistSearchQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Psycologists.Where(s => s.isActive);

            if (!string.IsNullOrWhiteSpace(request.PsicologoId))
                query = query.Where(s => s.PsychologistId == request.PsicologoId);

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(s => s.Name.Contains(request.Name));

            if (!string.IsNullOrWhiteSpace(request.State))
                query = query.Where(s => s.State == request.State);

            var psicologos = query.ToList();

            return psicologos;
        }
    }
}