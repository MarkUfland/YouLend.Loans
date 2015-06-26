using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Application.Events;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Common.Events;

namespace YouLend.Loans.Test.Application
{
    [TestClass]
    public class When_Storing_AnEvent_To_The_Event_Store
    {
        [TestMethod]
        public void Then_The_Event_Is_Stored_Correctly()
        {
            var eventRepository = new EventRepository();
            var loanCreatedEvent = new LoanCreatedEvent( Guid.NewGuid(), 1000m );

            var eventBody = EventSerialiser.Instance.Serialize(loanCreatedEvent);
            var storedEvent = new StoredEvent(loanCreatedEvent.GetType().ToString(), DateTime.UtcNow, eventBody);

            eventRepository.Add(storedEvent);
        }
    }
}
