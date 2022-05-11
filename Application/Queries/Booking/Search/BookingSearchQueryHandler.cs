using Application.Interfaces;
using MediatR;

namespace Application.Queries.Booking.Search
{
    public class BookingSearchQueryHandler : IRequestHandler<BookingSearchQuery, List<ScheduleOfTheDay>>
    {
        private readonly IContext _context;

        public BookingSearchQueryHandler(IContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleOfTheDay>> Handle(BookingSearchQuery request, CancellationToken cancellationToken)
        {
            var dayOfTheWeek = request.Date.DayOfWeek.ToString();

            var schedules = _context.Schedules
                .Where(s => s.PsychologistId == request.PsychologistId && s.Day == dayOfTheWeek)
                .ToList();

            var bookings = _context.ScheduleBookings
                .Where(s => s.PsycologistId == request.PsychologistId && s.Date.Date == request.Date.Date)
                .ToList();

            var schedulesOfTheDay = new List<ScheduleOfTheDay>(schedules.Count);

            foreach (var schedule in schedules)
            {
                schedulesOfTheDay.Add(new ScheduleOfTheDay
                {
                    IsBooked = bookings.Any(s => s.Date.ToString("HH:mm") == schedule.Time),
                    TimeOfDay = schedule.Time
                });
            }

            return schedulesOfTheDay;
        }
    }
}