using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Application.Events;

namespace YouLend.Loans.Test.Ports.Adapters.Notifications
{
    [TestClass]
    public class When_Retrieving_Events
    {
        [TestMethod]
        public void Then_The_Correct_Events_Are_Retrieved()
        {
            var eventRepository = new EventRepository();

        }
    }
}
