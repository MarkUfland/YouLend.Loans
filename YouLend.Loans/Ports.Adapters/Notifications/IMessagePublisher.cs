using System;
using YouLend.Common.Events;
namespace YouLend.Loans.Ports.Adapters.Notifications
{
    public interface IMessagePublisher
    {
        void PublishMessage(StoredEvent storedEvent);
    }
}
