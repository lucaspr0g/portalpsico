using Domain.Inputs.Psychologist;
using FluentValidation;

namespace Application.Validations.Psychologist
{
    internal class NewPsychologistValidator : AbstractValidator<NewPsychologist>
    {
        public NewPsychologistValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(s => s.Email)
                .NotEmpty()
                .MaximumLength(256)
                .EmailAddress();

            RuleFor(s => s.State)
                .NotEmpty()
                .MaximumLength(2);

            RuleFor(s => s.CRP)
                .NotEmpty()
                .MaximumLength(6);

            RuleFor(s => s.Approach)
                .MaximumLength(256);

            RuleFor(s => s.Description)
                .MaximumLength(256);
        }
    }
}