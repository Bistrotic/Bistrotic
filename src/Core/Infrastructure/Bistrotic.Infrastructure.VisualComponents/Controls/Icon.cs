namespace Bistrotic.Infrastructure.VisualComponents.Controls
{

    using System.Collections.Generic;

    public class Icon : BlazorComponent
    {
        public override IReadOnlyCollection<string> Classes
        {
            get
            {
                var classes = new HashSet<string>(base.Classes)
                {
                    //IconRenderer.RenderClass(this),
                    "icon-component"
                };
                return classes;
            }
        }
    }
}