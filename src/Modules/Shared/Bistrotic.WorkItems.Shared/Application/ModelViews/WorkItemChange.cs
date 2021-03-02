using System;

using Bistrotic.WorkItems.Domain;

namespace Bistrotic.WorkItems.Application.ModelViews
{
    public enum ChangeType
    {
        Update,
        Tchat
    }

    public class WorkItemChange
    {
        public DateTime ChangeDate { get; init; }
        public ChangeType ChangeType { get; init; }
        public string UserName { get; init; } = string.Empty;
        public WorkItemState State { get; set; }
    }
}