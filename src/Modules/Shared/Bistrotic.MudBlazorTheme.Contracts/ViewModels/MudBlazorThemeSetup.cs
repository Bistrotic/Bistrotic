using ProtoBuf;

namespace Bistrotic.MudBlazorTheme.ViewModels
{
    [ProtoContract]
    public class MudBlazorThemeSetup
    {
        [ProtoMember(1)]
        public int BaseColor { get; set; }

    }
}
