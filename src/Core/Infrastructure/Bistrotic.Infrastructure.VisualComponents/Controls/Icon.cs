namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using Bistrotic.Infrastructure.VisualComponents.Themes;

    using Microsoft.AspNetCore.Components;

    using System.Collections.Generic;

    public class Icon : BlazorComponent
    {
        #region Dependencies

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Inject]
        protected IIconRenderer IconRenderer { get; init; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #endregion Dependencies

        public override IReadOnlyCollection<string> Classes
        {
            get
            {
                var classes = new HashSet<string>(base.Classes)
                {
                    IconRenderer.RenderClass(this),
                    "icon-component"
                };
                return classes;
            }
        }
    }
}