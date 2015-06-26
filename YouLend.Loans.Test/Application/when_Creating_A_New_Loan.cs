using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Common.Ports.Adapters.Persistence;
using Ninject;
using YouLend.Loans.Ports.Adapters.IOC;
using YouLend.Common.Domain.Model;

namespace YouLend.Loans.Test.Application
{
    [TestClass]
    public class When_Creating_A_New_Loan
    {
        [TestMethod]
        public void Then_The_LoanCreatedEvent_Is_Handled_By_The_LoanCreatedEventHandler()
        {
            var kernel = new StandardKernel();

            kernel.Load<ApplicationIOCModule>();
            
            DomainEventPublisher.Container = kernel;

            var loanAmount = new MonetaryAmount(1000, new Currency("GBP", "British Pounds"));
            var loanId = new LoanId(Guid.NewGuid().GetAsGuidComb());
            var loan = Loan.CreateNewLoan(loanId, loanAmount);

        }
    }
}
