using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Common.Ports.Adapters.Persistence.NHibernatePersistence;

namespace YouLend.Loans.Application.Events
{
    public class EventRepository : DataRepositoryBase<StoredEvent>, IEventRepository
    {
    }
}
