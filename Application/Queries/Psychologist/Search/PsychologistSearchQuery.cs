using Domain.Entities;
using MediatR;

namespace Application.Queries.Psychologist.Search
{
    public class PsychologistSearchQuery : IRequest<List<Domain.Entities.Psychologist>>
    {
        public PsychologistSearchQuery(string? psicologoId, string? name, string? state)
        {
            Name = name;
            State = state;
            PsicologoId = psicologoId;
        }

        public string? PsicologoId { get; }

        public string? Name { get; }

        public string? State { get; }
    }
}