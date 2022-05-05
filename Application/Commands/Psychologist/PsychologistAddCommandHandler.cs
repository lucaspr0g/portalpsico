using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Psychologist
{
	public class PsychologistAddCommandHandler : IRequestHandler<PsychologistAddCommand>
	{
		private readonly IContext _context;

		public PsychologistAddCommandHandler(IContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(PsychologistAddCommand request, CancellationToken cancellationToken)
		{
			if (request.NewPsychologist is null)
				throw new InvalidRequestException("Invalid request");

			if (string.IsNullOrWhiteSpace(request.NewPsychologist.Nome))
				throw new InvalidRequestException("Preencha o nome");

			if (string.IsNullOrWhiteSpace(request.NewPsychologist.Email))
				throw new InvalidRequestException("Preencha o email");

			if (string.IsNullOrWhiteSpace(request.NewPsychologist.Estado))
				throw new InvalidRequestException("Selecione o estado");

			if (string.IsNullOrWhiteSpace(request.NewPsychologist.CRP))
				throw new InvalidRequestException("Preencha o CRP");

			if (string.IsNullOrWhiteSpace(request.NewPsychologist.Abordagem))
				throw new InvalidRequestException("Preencha a abordagem");

			if (string.IsNullOrWhiteSpace(request.NewPsychologist.Descricao))
				throw new InvalidRequestException("Preencha a descrição");

			var psicologo = new Psicologo
			{
				Nome = request.NewPsychologist.Nome,
				Email = request.NewPsychologist.Email,
				Estado = request.NewPsychologist.Estado,
				CRP = request.NewPsychologist.CRP,
				Abordagem = request.NewPsychologist.Abordagem,
				Descricao = request.NewPsychologist.Descricao,
				AprovadoEPSI = request.NewPsychologist.AprovadoEPSI
			};

			var psicologoId = psicologo.GenerateId(false);

			var existsPsicologoId = _context.Psicologos.Any(s => s.PsicologoId == psicologoId);

			if (existsPsicologoId)
				psicologoId = psicologo.GenerateId(true);

			psicologo.PsicologoId = psicologoId;

			_context.Psicologos.Add(psicologo);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}