using MediatR;

namespace Application.Queries.Booking.Search
{
    public class BookingSearchQuery : IRequest<List<ScheduleOfTheDay>>
    {
        public BookingSearchQuery(string? psychologistId, DateTime date)
        {
            PsychologistId = psychologistId;
            Date = date;
        }

        public string PsychologistId { get; }

        public DateTime Date { get; }
    }
}