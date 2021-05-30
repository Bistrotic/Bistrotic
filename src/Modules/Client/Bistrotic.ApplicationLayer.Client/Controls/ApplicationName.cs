namespace Bistrotic.ApplicationLayer.Controls
{
    using System.Threading.Tasks;

    using Bistrotic.ApplicationLayer.Queries;
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

        protected override async Task OnParametersSetAsync()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                _name = await QueryService.Ask<GetApplicationName, string>(new GetApplicationName());
            }
            await base.OnParametersSetAsync();
        }
    }
}