using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Common.Ports.Adapters.Persistence.NHibernatePersistence;

namespace YouLend.Loans.Application.Events
{
    public class EventRepository : DataRepositoryBase<StoredEvent>, IEventRepository
    {
        public IList<StoredEvent> GetUnpublishedEvents()
        {
            base.session.BeginTransaction();
            var unpublishedEventsQuery = base.session.CreateSQLQuery("select * from EventStore with (updlock, readpast) where Published = 0")
                                                     .AddEntity(typeof(StoredEvent));

            var unpublishedEvents = unpublishedEventsQuery.List<StoredEvent>();

            return unpublishedEvents;
        }

        public void UpdatePublishedEvents(IList<StoredEvent> events)
        {
            foreach (var storedEvent in events)
            {
                base.Save(storedEvent);
            }

            base.session.Transaction.Commit();
        }
    }
}
