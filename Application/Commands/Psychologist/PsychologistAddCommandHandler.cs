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
				Name = request.NewPsychologist.Nome,
				Email = request.NewPsychologist.Email,
				State = request.NewPsychologist.Estado,
				CRP = request.NewPsychologist.CRP,
				Approach = request.NewPsychologist.Abordagem,
				Description = request.NewPsychologist.Descricao,
				ApprovedEPSI = request.NewPsychologist.AprovadoEPSI
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