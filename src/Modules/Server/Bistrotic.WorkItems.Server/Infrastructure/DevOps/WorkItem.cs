namespace Bistrotic.WorkItems.Infrastructure.DevOps
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.Services.WebApi;

    using Fd = WorkItemFieldType;
    using Wi = Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem;

    public class WorkItem
    {
        private readonly Wi _wi;

        public WorkItem(Wi workItem)
        {
            _wi = workItem;
        }

        public string AssignedTo
        {
            get
            {
                var assignee = (IdentityRef?)_wi.Fields[Fd.AssignedTo];
                if (assignee != null)
                {
                    return assignee.DisplayName;
                }
                return string.Empty;
            }
        }

        public string HtmlUrl
        {
            get
            {
                var link = (ReferenceLink?)_wi
                    .Links
                    .Links
                    .Where(p => p.Key == "html")
                    .Select(p => p.Value)
                    .FirstOrDefault();
                return link?.Href ?? string.Empty;
            }
        }

        public DateTime? ClosedDate => GetField<DateTime?>(Fd.ClosedDate);
        public DateTime CreatedDate => GetField<DateTime?>(Fd.CreatedDate) ?? DateTime.MinValue;
        public int Id => _wi.Id ?? 0;
        public long Priority => GetField<long>(Fd.Priority);
        public string TeamProject => GetField(Fd.TeamProject);
        public string Title => GetField(Fd.Title);

        private string GetField(string name)
        {
            return GetField<string>(name) ?? string.Empty;
        }

        private T? GetField<T>(string name)
        {
            if (_wi.Fields.TryGetValue(name, out object? value))
            {
                return (T)value;
            }
            return default;
        }
    }
}