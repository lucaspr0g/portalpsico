namespace Domain.Inputs.Booking
{
    public class NewBookingRequest
    {
        public string? PsychologistId { get; set; }

        public DateTime Date { get; set; }
    }
}