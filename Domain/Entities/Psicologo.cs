namespace Domain.Entities
{
    public class Psicologo : Auditable
    {
		private const string Space = " ";
		private const string Dash = "-";

		public string PsicologoId { get; set; }

        public string Nome { get; set; }

		public string? Email { get; set; }

		public string? Senha { get; set; }

		public string Estado { get; set; }

        public string CRP { get; set; }

        public string Abordagem { get; set; }

        public string Descricao { get; set; }

        public bool isActive { get; set; }

        public bool AprovadoEPSI { get; set; }

        public List<Agenda>? Agenda { get; set; }

        public string GenerateId(bool addRandomNumber)
		{
            var splitedName = Nome.Split(Space);
            var lastName = splitedName[splitedName.Length - 1];

            if (addRandomNumber)
                return string.Concat(splitedName[0], Dash, lastName, Dash, new Random().Next(1, 999));

            return string.Concat(splitedName[0], Dash, lastName);
		}
    }
}