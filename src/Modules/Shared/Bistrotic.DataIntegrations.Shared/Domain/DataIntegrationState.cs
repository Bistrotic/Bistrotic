namespace Bistrotic.DataIntegrations.Domain
{
    using System.Collections.Generic;

    using Bistrotic.DataIntegrations.Domain.Events;
    using Bistrotic.Domain;
    using System;
    public sealed class DataIntegrationState : EntityState
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;

        public void Apply(IReadOnlyList<object> events)
        {
            foreach (var @event in events)
            {
                switch (@event)
                {
                    case DataIntegrationSubmitted submitted:
                        Apply(submitted);
                        break;

                    default:
                        throw new NotSupportedException($"Event type '{@event.GetType().Name} is not supported by '{nameof(DataIntegrationState)}''");
                }
            }
        }

        private void Apply(DataIntegrationSubmitted submitted)
        {
            Name = submitted.Name;
            Description = submitted.Description;
            DocumentName = submitted.DocumentName;
            Document = submitted.Document;
        }
    }
}