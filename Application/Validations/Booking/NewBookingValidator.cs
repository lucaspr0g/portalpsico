using Domain.Inputs.Booking;
using FluentValidation;

namespace Application.Validations.Booking
{
    internal class NewBookingValidator : AbstractValidator<NewBookingRequest>
    {
        public NewBookingValidator()
        {
            RuleFor(s => s.PsychologistId)
                .NotEmpty();

            RuleFor(s => s.Date)
                .GreaterThan(DateTime.Now);
        }
    }
}