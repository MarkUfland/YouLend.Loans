using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Domain.Model;

namespace YouLend.Loans.Test.Domain
{
    [TestClass]
    public class When_Creating_A_New_Currency
    {
        [TestMethod]
        public void Then_A_New_Currency_Is_Correctly_Created()
        {
            var isoCurrencyCode = "USD";
            var isoCurrencyName = "American Dollars";
            var currency = new Currency(isoCurrencyCode, isoCurrencyName);

            Assert.AreEqual(currency.IsoCurrencyCode, isoCurrencyCode);
            Assert.AreEqual(currency.IsoCurrencyName, isoCurrencyName);
        }
    }
}
