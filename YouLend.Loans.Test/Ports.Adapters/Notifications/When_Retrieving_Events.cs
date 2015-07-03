using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLend.Loans.Application.Events;
using System.Linq;
using YouLend.Common.Events;
using YouLend.Loans.Domain.Model.Loans;
using Shuttle.ESB.Core;
using YouLend.Loans.Ports.Adapters.Notifications;

namespace YouLend.Loans.Test.Ports.Adapters.Notifications
{
    [TestClass]
    public class When_Retrieving_Events
    {
        [TestMethod]
        public void Then_The_Correct_Events_Are_Retrieved()
        {
            var eventRepository = new EventRepository();
            var messagePublisher = new MessagePublisher();
            var notificationReader = new NotificationsReader(eventRepository, messagePublisher);

            notificationReader.PublishNotifications();
        }
    }




   
}
