namespace Visma.HR.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }

        protected StoredEvent() { }

        public StoredEvent(Event newEvent,
                           string data,
                           string user)
        {
            Id = Guid.NewGuid();
            AggregateId = newEvent.AggregateId;
            MessageType = newEvent.MessageType;
            Data = data;
            User = user;
        }
    }
}
