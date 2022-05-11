namespace Domain.Entities
{
    public class Psychologist : Auditable
    {
		private const string Space = " ";
		private const string Dash = "-";

		public string PsychologistId { get; set; }

        public string Name { get; set; }

		public string? Email { get; set; }

		public string? Password { get; set; }

		public string State { get; set; }

        public string CRP { get; set; }

        public string Approach { get; set; }

        public string Description { get; set; }

        public bool isActive { get; set; }

        public bool ApprovedEPSI { get; set; }

        public List<Schedule>? Schedules { get; set; }

        public List<ScheduleBooking> ScheduleBookings { get; set; }

        public string GenerateId(bool addRandomNumber)
		{
            var splitedName = Name.Split(Space);
            var lastName = splitedName[splitedName.Length - 1];

            if (addRandomNumber)
                return string.Concat(splitedName[0], Dash, lastName, Dash, new Random().Next(1, 999));

            return string.Concat(splitedName[0], Dash, lastName);
		}
    }
}