using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Test.Domain
{
    [TestClass]
    public class When_Creating_A_New_Loan
    {
        [TestMethod]
        public void Then_A_New_Loan_Is_Created_Successfully()
        {
            var loanAmount = new MonetaryAmount(1000, new Currency("GBP", "British Pounds"));
            var loan = Loan.CreateNewLoan( loanAmount );

            Assert.IsTrue(loan != null);
        }
    }
}
