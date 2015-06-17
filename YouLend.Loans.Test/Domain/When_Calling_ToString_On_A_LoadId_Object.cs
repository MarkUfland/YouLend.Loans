using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Test.Domain
{
    [TestClass]
    public class When_Calling_ToString_On_A_LoadId_Object
    {
        [TestMethod]
        public void Then_The_Correctly_Formatted_Response_Is_Returned()
        {
            var id = Guid.NewGuid();
            var expectedResult = "LoanId: " + id.ToString();
            var loanId = new LoanId(id);
            var actualResult = loanId.ToString();

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
