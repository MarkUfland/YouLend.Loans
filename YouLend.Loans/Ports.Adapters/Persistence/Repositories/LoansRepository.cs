using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Ports.Adapters.Persistence.NHibernate;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Ports.Adapters.Persistence.Repositories
{
    public class LoansRepository : DataRepositoryBase<Loan>, ILoansRepository
    {
    }
}
