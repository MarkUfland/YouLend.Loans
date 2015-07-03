using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Loans.Messages
{
    public class LoanCreatedExternalEvent
    {
        public long EventId { get; set; }
        public DateTime OccurredOn { get; set; }
        public decimal LoanAmount { get; set; }
        public Guid LoanId { get; set; }
    }
}
