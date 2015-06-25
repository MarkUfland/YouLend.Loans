using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Loans.Domain.Model;
using YouLend.Loans.Ports.Adapters.Persistence.Repositories;

namespace YouLend.Loans.Test.Ports.Adapters.Persistence
{
    [TestClass]
    public class When_Calling_The_Add_Method_On_The_LoansRepository
    {
        [TestMethod]
        public void Then_A_Loan_Is_Added()
        {
            var loanAmount = new MonetaryAmount(1000, new Currency("USD", "Dollars"));
            var loanRepository = new LoansRepository();
            var loanId = loanRepository.GetNextIdentity();
            var loan = Loan.CreateNewLoan(loanId,loanAmount);
            var anotherLoanId = loanRepository.GetNextIdentity();
            var anotherLoan = Loan.CreateNewLoan(anotherLoanId, loanAmount);

            loanRepository.Add(loan);
            loanRepository.Add(anotherLoan);

            var expectedLoan = loanRepository.GetLoanByLoanId(loan.LoanId);

            Assert.IsTrue(loan.LoanId.Equals(expectedLoan.LoanId));
           
        }
    }
}
