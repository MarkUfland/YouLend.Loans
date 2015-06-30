using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Common.Ports.Adapters.Persistence;
using Ninject;
using YouLend.Loans.Ports.Adapters.IOC;
using YouLend.Common.Domain.Model;
using YouLend.Loans.Application.Loans;

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

        [TestMethod]
        public void Then_The_Loan_Is_Created_In_The_Database()
        {
            var kernel = new StandardKernel();

            kernel.Load<ApplicationIOCModule>();
            kernel.Load<DataAccessIOCModule>();

            DomainEventPublisher.Container = kernel;

            var loanApplicationService = kernel.Get<LoanApplicationService>();
            var createLoanCommand = new CreateLoanCommand() { Amount = 999m, CurrencyISOCode = "GBP", PartyId = Guid.NewGuid() };
            loanApplicationService.CreateLoan(createLoanCommand);

        }

    }
}
