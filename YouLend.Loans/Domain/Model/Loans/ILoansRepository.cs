using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Ports.Adapters.Persistence;
using YouLend.Common.Ports.Adapters.Persistence.NHibernate;

namespace YouLend.Loans.Domain.Model.Loans
{
    public interface ILoansRepository : IDataRepository<Loan>
    {
    }
}
