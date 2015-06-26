using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Ports.Adapters.Persistence;

namespace YouLend.Common.Events
{
    public interface IEventRepository : IDataRepository<StoredEvent>
    {
    }
}
