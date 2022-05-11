using MediatR;

namespace Application.Commands.Booking.NewBooking
{
    public class NewBookingCommand : IRequest
    {
        public NewBookingCommand(string? psychologistId, DateTime date)
        {
            NewBooking = new NewBooking
            {
                PsychologistId = psychologistId,
                Date = date
            };
        }

        public NewBooking NewBooking { get; }
    }
}