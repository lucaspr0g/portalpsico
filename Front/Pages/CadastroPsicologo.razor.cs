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

        public string? Name { get; set; }

		public string? Email { get; set; }

		public string? State { get; set; }

        public string? CRP { get; set; }

        public string? Approach { get; set; }

        public string? Description { get; set; }

		public bool ApprovedEPSI { get; set; }

        public async Task Add()
		{
			try
			{
                isProcessing = true;
                _error = null;
                _showErrorAlert = false;
                _showSuccessAlert = false;

                var newPsychologist = new NewPsychologist
                {
                    Approach = Approach, 
                    ApprovedEPSI = ApprovedEPSI,
                    CRP = CRP,
                    Description = Description,
                    State = State,
                    Name = Name,
                    Email = Email
                };

                await mediator.Send(new PsychologistAddCommand(newPsychologist));

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