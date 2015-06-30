using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Events;
using YouLend.Loans.Application;
using YouLend.Loans.Application.Loans;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Ports.Adapters.IOC
{
    public class ApplicationIOCModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IHandle<LoanCreatedEvent>>().To<LoanCreatedEventHandler>();
            Bind<IHandle<IDomainEvent>>().To<AllEventsHandler>();
        }
    }
}
