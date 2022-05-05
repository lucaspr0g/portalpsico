namespace Domain.Entities
{
    public class Agenda : Auditable
    {
        public int AgendaId { get; set; }

        public string PsicologoId { get; set; }

        public string? Domingo { get; set; }

        public string? Segunda { get; set; }

        public string? Terça { get; set; }

        public string? Quarta { get; set; }

        public string? Quinta { get; set; }

        public string? Sexta { get; set; }

        public string? Sabado { get; set; }

        public Psicologo Psicologo { get; set; }
    }
}