using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Domain.Model;

namespace YouLend.Common.Events
{
    public class StoredEvent : IEquatable<StoredEvent>
    {
        protected StoredEvent()
        {

        }

        public StoredEvent(string typeName, DateTime occurredOn, string eventBody, long eventId = -1L)
        {
            Guard.AssertArgumentNotEmpty(typeName, "The event type name is required.");
            Guard.AssertArgumentLength(typeName, 100, "The event type name must be 100 characters or less.");

            Guard.AssertArgumentNotEmpty(eventBody, "The event body is required.");


            this.typeName = typeName;
            this.occurredOn = occurredOn;
            this.eventBody = eventBody;
            this.eventId = eventId;
        }

        public StoredEvent(string typeName, DateTime dateTime, string p)
        {
            // TODO: Complete member initialization
            this.typeName = typeName;
            this.dateTime = dateTime;
            this.p = p;
        }

        readonly string typeName;

        public virtual string TypeName
        {
            get { return typeName; }
        }

        readonly DateTime occurredOn;

        public virtual DateTime OccurredOn
        {
            get { return occurredOn; }
        }

        readonly string eventBody;

        public virtual string EventBody
        {
            get { return eventBody; }
        }

        readonly long eventId;
        private DateTime dateTime;
        private string p;

        public virtual long EventId
        {
            get { return eventId; }
        }

        public virtual IDomainEvent ToDomainEvent()
        {
            return ToDomainEvent<IDomainEvent>();
        }

        public virtual TEvent ToDomainEvent<TEvent>()
            where TEvent : IDomainEvent
        {
            var eventType = default(Type);
            try
            {
                eventType = Type.GetType(this.typeName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    string.Format("Class load error, because: {0}", ex));
            }
            return (TEvent)EventSerialiser.Instance.Deserialize(this.eventBody, eventType);
        }

        public virtual bool Equals(StoredEvent other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (object.ReferenceEquals(null, other)) return false;
            return this.eventId.Equals(other.eventId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StoredEvent);
        }

        public override int GetHashCode()
        {
            return this.eventId.GetHashCode();
        }
    }

}
