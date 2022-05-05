using Application.Commands.Psychologist;
using Domain.Inputs.Psychologist;

namespace Front.Pages
{
    public partial class CadastroPsicologo
    {
        private string? _error;
        private bool _showErrorAlert;

        private string? _message = "Psicólogo cadastrado com sucesso! Aguarde as próximas etapas via email.";
        private bool _showSuccessAlert;

        private bool isProcessing = false;

        public string? Nome { get; set; }

		public string? Email { get; set; }

		public string? Estado { get; set; }

        public string? CRP { get; set; }

        public string? Abordagem { get; set; }

        public string? Descricao { get; set; }

		public bool AprovadoEPSI { get; set; }

        public async Task Add()
		{
			try
			{
                isProcessing = true;
                _error = null;
                _showErrorAlert = false;
                _showSuccessAlert = false;

                var novoPsicologo = new NovoPsicologo
                {
                    Abordagem = Abordagem, 
                    AprovadoEPSI = AprovadoEPSI,
                    CRP = CRP,
                    Descricao = Descricao,
                    Estado = Estado,
                    Nome = Nome,
                    Email = Email
                };

                await mediator.Send(new PsychologistAddCommand(novoPsicologo));

                _showSuccessAlert = true;
			}
            catch (Exception ex)
			{
                _error = ex.Message;
                _showErrorAlert = true;
            }
            finally
			{
                isProcessing = false;
			}
        }
	}
}