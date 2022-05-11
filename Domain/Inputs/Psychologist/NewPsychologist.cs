namespace Domain.Inputs.Psychologist
{
	public class NewPsychologist
	{
        public string Name { get; set; }

		public string? Email { get; set; }

		public string State { get; set; }

        public string CRP { get; set; }

        public string Approach { get; set; }

        public string Description { get; set; }

        public bool ApprovedEPSI { get; set; }
    }
}