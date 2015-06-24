using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Domain.Model;

namespace YouLend.Loans.Domain.Model.Loans
{
    public class LoanId : ValueObject<LoanId>
    {
        public virtual Guid Id { get; private set; }

        protected LoanId()
        {
        }

        public LoanId(Guid id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return "LoanId: " + Id.ToString();
        }
    }
}
