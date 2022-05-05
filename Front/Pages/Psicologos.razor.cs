using Application.Queries.Psychologist.Search;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Front.Pages
{
    public partial class Psicologos
    {
        private Psicologo? _psicologo;

        [Parameter]
        public string? PsicologoId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _psicologo = (await mediator.Send(new PsychologistSearchQuery(default, default, default)))?.FirstOrDefault();
        }
    }
}