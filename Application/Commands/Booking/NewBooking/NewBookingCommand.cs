using Domain.Inputs.Booking;
using MediatR;

namespace Application.Commands.Booking.NewBooking
{
    public class NewBookingCommand : IRequest
    {
        public NewBookingCommand(string? psychologistId, DateTime date)
        {
            NewBooking = new NewBookingRequest
            {
                PsychologistId = psychologistId,
                Date = date
            };
        }

        public NewBookingRequest NewBooking { get; }
    }
}