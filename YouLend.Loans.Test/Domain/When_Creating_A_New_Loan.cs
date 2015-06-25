using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Common.Ports.Adapters.Persistence;
using YouLend.Common.Domain.Model;

namespace YouLend.Loans.Test.Domain
{
    [TestClass]
    public class When_Creating_A_New_Loan
    {
        [TestMethod]
        public void Then_A_New_Loan_Is_Created_Successfully()
        {
            var loanAmount = new MonetaryAmount(1000, new Currency("GBP", "British Pounds"));
            var loanId = new LoanId(Guid.NewGuid().GetAsGuidComb());
            var loan = Loan.CreateNewLoan(loanId, loanAmount );

            Assert.IsTrue(loan != null);
        }

        [TestMethod]
        public void Then_The_Correct_Event_Is_Raised()
        {
            Guid newLoanId = Guid.Empty;
            var newLoanAmount = 0m;
            DomainEventPublisher.Register<LoanCreatedEvent>(l => { 
                                                                    newLoanId = l.LoanId; 
                                                                    newLoanAmount = l.Amount; 
                                                                 });
        }

    }
}
