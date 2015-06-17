using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Loans.Domain.Model
{
    public class Currency
    {
        public string IsoCurrencyCode { get; private set; }
        public string IsoCurrencyName { get; private set; }

        public Currency(string isoCurrencyCode, string isoCurrencyName)
        {
            this.IsoCurrencyCode = isoCurrencyCode;
            this.IsoCurrencyName = isoCurrencyName;
        }
    }
}
