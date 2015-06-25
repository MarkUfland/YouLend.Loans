using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Loans.Domain.Model.Loans;
using System.Linq.Expressions;
using System.Reflection;
using YouLend.Common.Ports.Adapters.Persistence.NHibernatePersistence;
using YouLend.Common.Ports.Adapters.Persistence;

namespace YouLend.Loans.Ports.Adapters.Persistence.Repositories
{
    public class LoansRepository : DataRepositoryBase<Loan>, ILoansRepository
    {
        public Loan GetLoanByLoanId(LoanId loanId)
        {
            var lambdaHelper = new LambdaHelper();

            var loanLambdaObject = lambdaHelper.CreateLambdaObject<Loan>();

            var loanIdLambdaPredicate = lambdaHelper.CreateLambdaPredicate<Loan>(fieldName: "LoanId.Id", criteria: Criteria.EqualTo, value: loanId.Id);

            var fullLambdaEpression = lambdaHelper.CreateFullLambdaExpression<Loan>(aLambdaObject: loanLambdaObject, aLambdaExpression: loanIdLambdaPredicate);

            Loan loan = base.GetByCriteria(fullLambdaEpression).First();

            return loan;
           
        }

        public LoanId GetNextIdentity()
        {
            return new LoanId(Guid.NewGuid().GetAsGuidComb());
        }
    }
}
