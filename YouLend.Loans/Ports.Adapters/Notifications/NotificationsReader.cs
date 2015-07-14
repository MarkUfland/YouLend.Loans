using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;

namespace YouLend.Loans.Ports.Adapters.Notifications
{
    public class NotificationsReader
    {
        private IEventRepository eventRepository;
        private IMessagePublisher messagePublisher;

        public NotificationsReader(IEventRepository eventRepository, IMessagePublisher messagePublisher)
        {
            this.eventRepository = eventRepository;
            this.messagePublisher = messagePublisher;
        }

        public void PublishNotifications()
        {
            var unpublishedEvents = this.eventRepository.GetUnpublishedEvents();

            foreach (StoredEvent storedEvent in unpublishedEvents)
            {
                try
                {
                    messagePublisher.PublishMessage(storedEvent);
                    storedEvent.Published = true;
                }

                catch (Exception ex)
                {
                }
            }

            this.eventRepository.UpdatePublishedEvents(unpublishedEvents);
        }
    }
}
