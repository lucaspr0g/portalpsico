using Domain.Inputs.Psychologist;
using MediatR;

namespace Application.Commands.Psychologist
{
    public class PsychologistAddCommand : IRequest
    {
        public PsychologistAddCommand(NewPsychologist newPsychologist)
        {
            NewPsychologist = newPsychologist;
        }

		public NewPsychologist NewPsychologist { get; }
	}
}