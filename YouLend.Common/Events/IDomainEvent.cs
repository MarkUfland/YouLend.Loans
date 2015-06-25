using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Common.Events
{
    public interface IDomainEvent
    {
        int EventVersion { get; }
        DateTime DateTimeEventOccurred { get; }
    }
}
