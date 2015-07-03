using Shuttle.ESB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Loans.Ports.Adapters.Notifications.EventMappers;

namespace YouLend.Loans.Ports.Adapters.Notifications
{
    public class MessagePublisher : IMessagePublisher
    {
        public void PublishMessage(StoredEvent storedEvent)
        {
            var loanCreatedEventMapper = new LoanCreatedEventMapper();
            var externalCreatedEvent = loanCreatedEventMapper.Map(storedEvent);
            TransportMessage transportMessage;

            using (var bus = ServiceBus.Create().Start())
            {
                transportMessage = bus.Send(externalCreatedEvent);
                
                if (transportMessage.FailureMessages.Count > 0)
                {
                    throw new Exception("Failed to send message");
                }                
            }
        }
    }
}
