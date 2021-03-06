﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;

namespace YouLend.Loans.Ports.Adapters.Notifications.EventMappers
{
    public interface IExternalMessageMapper
    {
    }

    public interface IExternalMessageMapper<T> : IExternalMessageMapper
    {
        T Map(StoredEvent storedEvent);
    }

}
