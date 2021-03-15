namespace Bistrotic.Infrastructure.BlazorClient.Components
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public abstract class BlazorInput<T> : InputBase<T>
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [CascadingParameter]
        protected Theme? ThemeProvider { get; set; }
    }
}