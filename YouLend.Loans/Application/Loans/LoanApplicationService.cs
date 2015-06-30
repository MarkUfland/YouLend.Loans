using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YouLend.Loans.Domain.Model;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Application.Loans
{
    public class LoanApplicationService
    {
        private ILoansRepository loansRepository;
        
        public LoanApplicationService(ILoansRepository loansRepository)
        {
            this.loansRepository = loansRepository;
        }

        public void CreateLoan( CreateLoanCommand createLoanCommand )
        {
            using( TransactionScope tx = new TransactionScope() )
            {
                var currency = new Currency(createLoanCommand.CurrencyISOCode, "pls fix this");
                var loanAmount = new MonetaryAmount( createLoanCommand.Amount, currency );
                var loanId = loansRepository.GetNextIdentity();
                var loan = Loan.CreateNewLoan(loanId,loanAmount);
            
                this.loansRepository.Add(loan);

                tx.Complete();
                // Raise event to say loan created
            }
        }
    }
}
