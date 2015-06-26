using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Common.Ports.Adapters.Persistence;

namespace YouLend.Loans.Application
{
    public class AllEventsHandler : IHandle<IDomainEvent>
    {
        private readonly IDataRepositoryFactory dataRepositoryFactory;

        public AllEventsHandler(IDataRepositoryFactory dataRepositoryFactory)
        {
            this.dataRepositoryFactory = dataRepositoryFactory;
        }

        public void Handle(IDomainEvent args)
        {
            var eventToStore = new StoredEvent(typeName: args.GetType().FullName, 
                                               occurredOn: args.DateTimeEventOccurred,
                                               eventBody: EventSerialiser.Instance.Serialize(args));

            var eventRepository = dataRepositoryFactory.RetrieveDataRepository<IEventRepository>();

            eventRepository.Add(eventToStore);
        }
    }
}
