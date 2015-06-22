﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Loans.Domain.Model.Loans
{
    public class Loan
    {
        public LoanId LoanId { get; private set; }
        public MonetaryAmount LoanAmount { get; private set; }


        protected Loan()
        {
        }

        protected Loan(LoanId loanId, MonetaryAmount loanAmount)
        {
            this.LoanId = loanId;
            this.LoanAmount = loanAmount;
        }

        public void TopUpLoan(MonetaryAmount amountToTopUp)
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
