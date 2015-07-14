using Castle.Windsor;
using Shuttle.ESB.Castle;
using Shuttle.ESB.Core;
using Shuttle.ESB.SqlServer;
using Shuttle.ESB.SqlServer.Idempotence;
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
        private WindsorContainer container;

        public void PublishMessage(StoredEvent storedEvent)
        {
            var loanCreatedEventMapper = new LoanCreatedEventMapper();
            var externalCreatedEvent = loanCreatedEventMapper.Map(storedEvent);
            TransportMessage transportMessage;

            container = new WindsorContainer();

            using( var bus = ServiceBus.Create(c => c.MessageHandlerFactory(new CastleMessageHandlerFactory(container))
                              .SubscriptionManager(SubscriptionManager.Default())).Start())
            {
                var outboundTransportMessage = bus.CreateTransportMessage(externalCreatedEvent, null);

                var configurator = new TransportMessageConfigurator(externalCreatedEvent);

                //bus.Dispatch(outboundTransportMessage);
                
                
                //transportMessage = bus.Send(externalCreatedEvent,Configure);
                bus.Publish(externalCreatedEvent);
                
                //if (transportMessage.FailureMessages.Count > 0)
                //{
                //    throw new Exception("Failed to send message");
                //}                
            }
        }

        private void Configure(TransportMessageConfigurator configurator)
        {
            int a = 1;
        }
    }
}
