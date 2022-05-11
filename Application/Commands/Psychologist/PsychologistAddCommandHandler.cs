using Application.Exceptions;
using Application.Interfaces;
using Application.Validations.Psychologist;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Psychologist
{
	public class PsychologistAddCommandHandler : IRequestHandler<PsychologistAddCommand>
	{
		private readonly IContext _context;
		private readonly NewPsychologistValidator _validator = new();

		public PsychologistAddCommandHandler(IContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(PsychologistAddCommand request, CancellationToken cancellationToken)
		{
			if (request.NewPsychologist is null)
				throw new InvalidRequestException("Invalid request");

			var validatorResult = _validator.Validate(request.NewPsychologist);

			if (!validatorResult.IsValid)
				throw new InvalidRequestException(string.Join(" ", validatorResult.Errors));

			var psicologo = new Domain.Entities.Psychologist
			{
				Name = request.NewPsychologist.Name,
				Email = request.NewPsychologist.Email,
				State = request.NewPsychologist.State,
				CRP = request.NewPsychologist.CRP,
				Approach = request.NewPsychologist.Approach,
				Description = request.NewPsychologist.Description,
				ApprovedEPSI = request.NewPsychologist.ApprovedEPSI
			};

			var psicologoId = psicologo.GenerateId(false);

			var existsPsicologoId = _context.Psycologists.Any(s => s.PsychologistId == psicologoId);

			if (existsPsicologoId)
				psicologoId = psicologo.GenerateId(true);

			psicologo.PsychologistId = psicologoId;

			_context.Psycologists.Add(psicologo);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}