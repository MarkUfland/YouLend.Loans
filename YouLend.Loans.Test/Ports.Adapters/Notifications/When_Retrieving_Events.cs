using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Application.Events;
using System.Linq;
using YouLend.Common.Events;
using YouLend.Loans.Domain.Model.Loans;
using Shuttle.ESB.Core;

namespace YouLend.Loans.Test.Ports.Adapters.Notifications
{
    [TestClass]
    public class When_Retrieving_Events
    {
        [TestMethod]
        public void Then_The_Correct_Events_Are_Retrieved()
        {
            var eventRepository = new EventRepository();
            var unpublishedEvents = eventRepository.GetUnpublishedEvents();
            var messagePublisher = new MessagePublisher();

            foreach (StoredEvent storedEvent in unpublishedEvents)
            {
                messagePublisher.PublishMessage(storedEvent);
            }

            eventRepository.UpdatePublishedEvents(unpublishedEvents);

        }


    }

    public class MessagePublisher
    {
        public void PublishMessage(StoredEvent storedEvent)
        {
            var loanCreatedEventMapper = new LoanCreatedEventMapper();
            var externalCreatedEvent = loanCreatedEventMapper.Map(storedEvent);

            using (var bus = ServiceBus.Create().Start())
            {
                bus.Send(externalCreatedEvent);
            }
        }
    }

    public class ExternalLoanCreatedEvent
    {
        public long EventId { get; set; }
        public DateTime OccurredOn { get; set; }
        public decimal LoanAmount { get; set; }
        public Guid LoanId{ get; set; }
    }

    public class LoanCreatedEventMapper
    {
        public ExternalLoanCreatedEvent Map(StoredEvent storedEvent)
        {
            var loanCreatedEvent = EventSerialiser.Instance.Deserialize<LoanCreatedEvent>(storedEvent.EventBody);
            var externalLoanCreatedEvent = new ExternalLoanCreatedEvent()
            {
                EventId = storedEvent.EventId,
                OccurredOn = loanCreatedEvent.DateTimeEventOccurred,
                LoanAmount = loanCreatedEvent.Amount,
                LoanId = loanCreatedEvent.LoanId
            };

            return externalLoanCreatedEvent;
        }
    }
}
