using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Common.Domain.Model;

namespace YouLend.Loans.Domain.Model
{
    public class MonetaryAmount : ValueObject<MonetaryAmount>
    {
        private decimal amount;
        private Currency currency;

        public MonetaryAmount(decimal amount, Currency currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public decimal Amount
        {
            get { return amount; }
            private set { amount = value; }
        }

        public Currency Currency
        {
            get { return currency; }
            private set { currency = value; }
        }

        public MonetaryAmount AddMonetaryAmount(MonetaryAmount amount2)
        {
            var total = this.Amount + amount2.Amount;

            return new MonetaryAmount( total, this.Currency );
        }
    }
}
