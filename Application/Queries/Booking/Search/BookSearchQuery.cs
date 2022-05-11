using MediatR;

namespace Application.Queries.Booking.Search
{
    public class BookSearchQuery : IRequest<List<ScheduleOfTheDay>>
    {
        public BookSearchQuery(string? psychologistId, DateTime date)
        {
            PsychologistId = psychologistId;
            Date = date;
        }

        public string PsychologistId { get; }

        public DateTime Date { get; }
    }
}