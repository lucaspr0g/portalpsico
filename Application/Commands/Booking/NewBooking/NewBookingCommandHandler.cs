using Application.Exceptions;
using Application.Interfaces;
using Application.Validations.Booking;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Booking.NewBooking
{
    public class NewBookingCommandHandler : IRequestHandler<NewBookingCommand>
    {
        private readonly IContext _context;
        private readonly NewBookingValidator _validator = new();

        public NewBookingCommandHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(NewBookingCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = _validator.Validate(request.NewBooking);

            if (!validatorResult.IsValid)
                throw new InvalidRequestException(string.Join(" ", validatorResult.Errors));

            var scheduleBooking = new ScheduleBooking
            {
                Date = request.NewBooking.Date,
                PsycologistId = request.NewBooking.PsychologistId
            };

            _context.ScheduleBookings.Add(scheduleBooking);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}