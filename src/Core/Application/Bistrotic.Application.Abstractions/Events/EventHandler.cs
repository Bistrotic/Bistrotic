#pragma warning disable CA1711 // Identifiers should not have incorrect suffix

namespace Bistrotic.Application.Events
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    public abstract class EventHandler<TEvent> : IEventHandler<TEvent>
        where TEvent : class
    {
        public bool CanHandle(Type EventType)
        {
            return EventType == typeof(TEvent);
        }

        public abstract Task Handle(Envelope<TEvent> envelope);

        public Task Handle(IEnvelope envelope)
           => Handle(new Envelope<TEvent>(envelope));
    }
}