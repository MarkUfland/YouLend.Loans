using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Loans.Application.Loans
{
    public class LoanApplicationService
    {
        public void CreateLoan(decimal loanAmount, Guid partyID )
        {
            // Create a new loan
            // Save loan to db
            // Raise event to say loan created
        }
    }
}
