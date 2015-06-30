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
        public virtual string TypeName { get; protected set; }
        public virtual DateTime OccurredOn { get; protected set; }
        public virtual string EventBody { get; protected set; }
        public virtual long EventId { get; protected set; }
        public virtual bool Published { get; set; }

        protected StoredEvent()
        {
        }

        public StoredEvent(string typeName, DateTime occurredOn, string eventBody, long eventId = -1L)
        {
            Guard.AssertArgumentNotEmpty(typeName, "The event type name is required.");
            Guard.AssertArgumentLength(typeName, 100, "The event type name must be 100 characters or less.");

            Guard.AssertArgumentNotEmpty(eventBody, "The event body is required.");

            this.TypeName = typeName;
            this.OccurredOn = occurredOn;
            this.EventBody = eventBody;
            this.EventId = eventId;
            this.Published = false;
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
                eventType = Type.GetType(this.TypeName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    string.Format("Class load error, because: {0}", ex));
            }
            return (TEvent)EventSerialiser.Instance.Deserialize(this.EventBody, eventType);
        }

        public virtual bool Equals(StoredEvent other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (object.ReferenceEquals(null, other)) return false;
            return this.EventId.Equals(other.EventId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StoredEvent);
        }

        public override int GetHashCode()
        {
            return this.EventId.GetHashCode();
        }
    }

}
