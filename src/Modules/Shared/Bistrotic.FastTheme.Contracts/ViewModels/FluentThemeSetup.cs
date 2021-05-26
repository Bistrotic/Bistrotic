using ProtoBuf;

namespace Bistrotic.FastTheme.ViewModels
{
    [ProtoContract]
    public class FluentThemeSetup
    {
        [ProtoMember(1)]
        public int BaseColor { get; set; }

    }
}
