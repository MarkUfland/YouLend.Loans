using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Loans.Messages;

namespace YouLend.Loans.Ports.Adapters.Notifications.EventMappers
{
    public class LoanCreatedEventMapper : IExternalMessageMapper<LoanCreatedExternalEvent>
    {
        public LoanCreatedExternalEvent Map(StoredEvent storedEvent)
        {
            var loanCreatedEvent = EventSerialiser.Instance.Deserialize<LoanCreatedEvent>(storedEvent.EventBody);
            var externalLoanCreatedEvent = new LoanCreatedExternalEvent()
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
