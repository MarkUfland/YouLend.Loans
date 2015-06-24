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

        public static Loan CreateNewLoan(MonetaryAmount loanAmount)
        {
            var loanId = new LoanId(Guid.NewGuid());
            var loan = new Loan(loanId, loanAmount);

            return loan;
        }
    }
}
