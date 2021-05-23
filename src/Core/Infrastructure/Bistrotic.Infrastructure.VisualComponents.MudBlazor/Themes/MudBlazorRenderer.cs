using Bistrotic.Infrastructure.VisualComponents.Controls;

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;

using MudBlazor;

using System;
using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public class MudBlazorRenderer : IComponentRenderer
    {
        private readonly ILogger<MudBlazorRenderer> _logger;

        public MudBlazorRenderer(ILogger<MudBlazorRenderer> logger)
        {
            _logger = logger;
        }

        public bool IsContainerTheme { get; }

        public IEnumerable<string> Scripts { get; } = new string[] { "_content/MudBlazor/MudBlazor.min.js" };

        public IEnumerable<string> Stylesheets { get; } = new string[]
                {
            "_content/MudBlazor/MudBlazor.min.css",
            "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
        };

        public IEnumerable<KeyValuePair<string, object?>> ThemeAttributes { get; } = Array.Empty<KeyValuePair<string, object?>>();
        public string ThemeTagName { get; } = "MudThemeProvider";

        public int BuildRenderTree(int sequence, BlazorComponent component, RenderTreeBuilder builder)
        {
            return component switch
            {
                Alert c => new AlertRenderer(c, builder).Render(sequence),
                MenuAnchor c => new MenuAnchorRenderer(c, builder).Render(sequence),
                Controls.Anchor c => new AnchorRenderer(c, builder).Render(sequence),
                ApplicationBar c => new ApplicationBarRenderer(c, builder).Render(sequence),
                ApplicationContent c => new ApplicationContentRenderer(c, builder).Render(sequence),
                ApplicationLayout c => new ApplicationLayoutRenderer(c, builder).Render(sequence),
                ApplicationMenu c => new ApplicationMenuRenderer(c, builder).Render(sequence),
                ApplicationName c => new ApplicationNameRenderer(c, builder).Render(sequence),
                ApplicationSearch c => new ApplicationSearchRenderer(c, builder).Render(sequence),
                Badge c => new BadgeRenderer(c, builder).Render(sequence),
                Controls.Button c => new ButtonRenderer(c, builder).Render(sequence),
                Icon c => new IconRenderer(c, builder).Render(sequence),
                Menu c => new MenuRenderer(c, builder).Render(sequence),
                MenuItem c => new MenuItemRenderer(c, builder).Render(sequence),
                Spacer c => new SpacerRenderer(c, builder).Render(sequence),
                _ => throw new NotImplementedException($"The control {component.GetType().Name} is not supported by {GetType().Name}")
            };
        }

        public int CloseTheme(int sequence, RenderTreeBuilder builder)
        {
            return sequence;
        }

        public int OpenTheme(int sequence, RenderTreeBuilder builder)
        {
            builder.OpenComponent(sequence++, typeof(MudThemeProvider));
            builder.CloseComponent();
            builder.OpenComponent(sequence++, typeof(MudDialogProvider));
            builder.CloseComponent();
            builder.OpenComponent(sequence++, typeof(MudSnackbarProvider));
            builder.CloseComponent();
            return sequence;
        }
    }
}