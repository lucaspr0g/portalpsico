using Application.Commands.Booking.NewBooking;
using FluentValidation;

namespace Application.Validations.Booking
{
    internal class NewBookingValidator : AbstractValidator<NewBooking>
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