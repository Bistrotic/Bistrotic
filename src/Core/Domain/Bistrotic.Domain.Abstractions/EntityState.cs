namespace Bistrotic.Domain
{
    using System;

    using Bistrotic.Domain.Messages;

    public class EntityState : IEntityState
    {
        public string CreatedBy { get; private set; } = string.Empty;

        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        public string Etag { get; private set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 22);

        public string Id { get; private set; } = string.Empty;

        public string? LastModifiedBy { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public virtual void Apply(IEvent @event, string etag)
        {
            if (@event.Etag == null)
                InitState(@event);
            else
                UpdateState(@event);
        }

        private void InitState(IEvent @event)
        {
            if (@event.Etag != null ||
                string.IsNullOrWhiteSpace(@event.MessageId) ||
                !string.IsNullOrWhiteSpace(Id) ||
                !string.IsNullOrWhiteSpace(CreatedBy) ||
                LastModifiedDate != null ||
                LastModifiedBy != null)
            {
                throw new StateInitializationException(@event, this);
            }
            Etag = @event.Etag?.Value ?? Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 22);
            Id = @event.MessageId;
            CreatedBy = @event.UserName;
            CreatedDate = DateTime.UtcNow;
        }

        private void UpdateState(IEvent @event)
        {
            if (@event.Etag == null ||
                string.IsNullOrWhiteSpace(@event.MessageId) ||
                string.IsNullOrWhiteSpace(Id))
            {
                throw new StateUpdateException(@event, this);
            }
            Etag = @event.Etag ?? Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 22);
            Id = @event.MessageId;
            CreatedBy = @event.UserName;
            CreatedDate = DateTime.UtcNow;
        }
    }
}