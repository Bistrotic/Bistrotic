﻿namespace Bistrotic.FastTheme.Queries
{
    using Bistrotic.Domain.Contracts.Projections;

    using ProtoBuf;

    [ProtoContract]
    [Query]
    public sealed class GetFastThemeSetup
    {
        [ProtoMember(1)]
        public string UserName { get; set; } = string.Empty;

    }
}