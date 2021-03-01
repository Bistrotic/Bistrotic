namespace Bistrotic.WorkItems.Application.Queries
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;

    public sealed class GetSecurityGroupMembers : Query<IEnumerable<SecurityGroupMember>>
    {
        public GetSecurityGroupMembers(string groupName)
        {
            GroupName = groupName;
        }

        [Obsolete("For serialization only")]
        public GetSecurityGroupMembers()
        {
            GroupName = string.Empty;
        }

        public string GroupName { get; }
    }
}