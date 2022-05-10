using Domain.Inputs.Psychologist;
using FluentValidation;

namespace Application.Validations.Psychologist
{
    internal class NewPsychologistValidator : AbstractValidator<NewPsychologist>
    {
        public NewPsychologistValidator()
        {
            RuleFor(s => s.Nome)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(s => s.Email)
                .NotEmpty()
                .MaximumLength(256)
                .EmailAddress();

            RuleFor(s => s.Estado)
                .NotEmpty()
                .MaximumLength(2);

            RuleFor(s => s.CRP)
                .NotEmpty()
                .MaximumLength(6);

            RuleFor(s => s.Abordagem)
                .MaximumLength(256);

            RuleFor(s => s.Descricao)
                .MaximumLength(256);
        }
    }
}