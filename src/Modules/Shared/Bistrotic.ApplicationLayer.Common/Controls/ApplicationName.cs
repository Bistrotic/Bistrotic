namespace Bistrotic.ApplicationLayer.Controls
{
    using System.Threading.Tasks;

    using Bistrotic.ApplicationLayer.Services;
    using Bistrotic.Infrastructure.VisualComponents;

    using Microsoft.AspNetCore.Components;

    public class ApplicationName : BlazorComponent
    {
        private string _name = string.Empty;

        [Parameter]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                StateHasChanged();
            }
        }

        [Inject]
        protected IApplicationNameService ApplicationNameService { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                _name = await ApplicationNameService.GetName();
            }
            await base.OnParametersSetAsync();
        }
    }
}