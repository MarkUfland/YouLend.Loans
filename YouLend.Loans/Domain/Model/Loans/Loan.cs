using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Domain.Model;

namespace YouLend.Loans.Domain.Model.Loans
{
    public class Loan 
    {
        public virtual LoanId LoanId { get; protected set; }
        public virtual MonetaryAmount LoanAmount { get; protected set; }


        protected Loan()
        {
        }

        protected Loan(LoanId loanId, MonetaryAmount loanAmount)
        {
            this.LoanId = loanId;
            this.LoanAmount = loanAmount;
        }

        public virtual void TopUpLoan(MonetaryAmount amountToTopUp)
        {
            this.LoanAmount = this.LoanAmount.AddMonetaryAmount( amountToTopUp );
        }

        public static Loan CreateNewLoan(LoanId loanId, MonetaryAmount loanAmount)
        {
            var loan = new Loan(loanId, loanAmount);
            var loanCreatedEvent = new LoanCreatedEvent(loanId.Id, loanAmount.Amount);
            DomainEventPublisher.Raise<LoanCreatedEvent>(loanCreatedEvent);

            return loan;
        }
    }
}
