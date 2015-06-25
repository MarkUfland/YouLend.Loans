using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;

namespace YouLend.Loans.Domain.Model.Loans
{
    public class LoanCreatedEvent : IDomainEvent
    { 
        public int EventVersion { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
        public Guid LoanId { get; private set; }
        public decimal Amount { get; private set; }

        public LoanCreatedEvent(Guid loanId, decimal amount)
        {
            LoanId = loanId;
            Amount = amount;
            DateTimeEventOccurred = DateTime.UtcNow;
            EventVersion = 1;
        }
    }
}
