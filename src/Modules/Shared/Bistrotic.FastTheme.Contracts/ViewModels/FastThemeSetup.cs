using ProtoBuf;

namespace Bistrotic.FastTheme.ViewModels
{
    [ProtoContract]
    public class FastThemeSetup
    {
        [ProtoMember(1)]
        public int BaseColor { get; set; }

    }
}
