using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Application.Loans
{
    public class LoanCreatedEventHandler : IHandle<LoanCreatedEvent>
    {
        public void Handle(LoanCreatedEvent args)
        {
            throw new NotImplementedException();
        }
    }
}
