using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;

namespace YouLend.Loans.Ports.Adapters.Persistence.MappingFiles
{
    internal class StoredEventMapper : ClassMap<StoredEvent>
    {
        public StoredEventMapper()
        {
            this.Table("EventStore");
            this.Id(x => x.EventId).GeneratedBy.Identity();

            this.Map(x => x.OccurredOn);
            this.Map(x => x.EventBody);
            this.Map(x => x.TypeName);

        }
    }
}
