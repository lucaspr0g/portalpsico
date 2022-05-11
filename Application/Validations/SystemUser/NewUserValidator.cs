using Domain.Inputs.User;
using FluentValidation;

namespace Application.Validations.SystemUser
{
    internal class NewUserValidator : AbstractValidator<NewUserRequest>
    {
        public NewUserValidator()
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

            RuleFor(s => s.Password)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(s => s.ConfirmPassword)
                .NotEmpty()
                .MaximumLength(20)
                .Equal(s => s.Password);
        }
    }
}