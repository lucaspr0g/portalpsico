using Domain.Inputs.Psychologist;
using MediatR;

namespace Application.Commands.Psychologist
{
    public class PsychologistAddCommand : IRequest
    {
        public PsychologistAddCommand(NovoPsicologo newPsychologist)
        {
            NewPsychologist = newPsychologist;
        }

		public NovoPsicologo NewPsychologist { get; }
	}
}