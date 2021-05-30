using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bistrotic.Infrastructure.WebServer.Settings
{
    public class WebServerSettings
    {
        public RenderMode ClientMode { get; init; } = RenderMode.Server;
    }
}