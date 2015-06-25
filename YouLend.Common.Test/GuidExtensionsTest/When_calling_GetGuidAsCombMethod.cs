using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Common.Ports.Adapters.Persistence;

namespace YouLend.Common.Test.GuidExtensionsTest
{
    [TestClass]
    public class When_calling_GetGuidAsCombMethod
    {
        [TestMethod]
        public void Then_a_Guid_Comb_IsReturned()
        {
            var guid = Guid.NewGuid().GetAsGuidComb();
            var anotherGuid = Guid.NewGuid().GetAsGuidComb();



        }
    }
}
