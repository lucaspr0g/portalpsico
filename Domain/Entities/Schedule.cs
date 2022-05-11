namespace Domain.Entities
{
    public class Schedule : Auditable
    {
        public int ScheduleId { get; set; }

        public string PsychologistId { get; set; }

        public string? Day { get; set; }

        public string? Time { get; set; }

        public Psychologist Psychologist { get; set; }
    }
}