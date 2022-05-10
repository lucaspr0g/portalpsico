namespace Domain.Inputs.Psychologist
{
	public class NewPsychologist
	{
        public string Nome { get; set; }

		public string? Email { get; set; }

		public string Estado { get; set; }

        public string CRP { get; set; }

        public string Abordagem { get; set; }

        public string Descricao { get; set; }

        public bool AprovadoEPSI { get; set; }
    }
}