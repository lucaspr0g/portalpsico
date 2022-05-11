namespace Domain.Entities
{
    public class ScheduleBooking : Auditable
    {
        public int BookingId { get; set; }

        public string? PsycologistId { get; set; }

        public DateTime Date { get; set; }

        public Psychologist Psycologist { get; set; }
    }
}