using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model;

namespace YouLend.Loans.Test.Domain
{
    [TestClass]
    public class When_Adding_Monetary_Amounts_Together
    {
        [TestMethod]
        public void Then_The_Correct_Amount_Is_Returned()
        {
            var amount1 = new MonetaryAmount(10m, new Currency("USD", "American Dollars"));
            var amount2 = new MonetaryAmount(50m, new Currency("USD", "American Dollars"));

            var totalledAmount = amount1.AddMonetaryAmount(amount2);

            Assert.AreEqual(totalledAmount.Amount, 60m);
        }
    }
}
