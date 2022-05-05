using Microsoft.AspNetCore.Components;

namespace Front.Components
{
    public partial class Search
    {
        public string? Name { get; set; }

        public string? State { get; set; }

        [Parameter]
        public EventCallback<string[]> OnSearchChanged { get; set; }

        private async Task OnInputChangeAsync(ChangeEventArgs args)
		{
            Name = (string?)args.Value;

            await OnSearchChanged.InvokeAsync(new string[2] { Name, State });
        }

        private async Task OnSelectChangeAsync(ChangeEventArgs args)
        {
            State = (string?)args.Value;

            await OnSearchChanged.InvokeAsync(new string[2] { Name, State });
        }
    }
}