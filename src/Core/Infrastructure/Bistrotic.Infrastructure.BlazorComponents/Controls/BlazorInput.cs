namespace Bistrotic.Infrastructure.BlazorComponents
{
    using Bistrotic.Infrastructure.BlazorComponents.Themes;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public abstract class BlazorInput<T> : InputBase<T>
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [CascadingParameter]
        protected IThemeRenderer? ThemeRenderer { get; set; }
    }
}