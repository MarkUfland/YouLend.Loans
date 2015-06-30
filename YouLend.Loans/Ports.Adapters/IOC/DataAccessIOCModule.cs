using Ninject.Modules;
using Ninject.Extensions.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Ports.Adapters.Persistence;
using YouLend.Loans.Domain.Model.Loans;
using YouLend.Loans.Ports.Adapters.Persistence.Repositories;
using YouLend.Common.Events;
using YouLend.Loans.Application.Events;

namespace YouLend.Loans.Ports.Adapters.IOC
{
    public class DataAccessIOCModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoansRepository>().To<LoansRepository>();
            Bind<IEventRepository>().To<EventRepository>();
            Bind<IDataRepositoryFactory>().ToFactory();
        }
    }
}
