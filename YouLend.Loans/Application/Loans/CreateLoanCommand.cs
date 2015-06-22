using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Loans.Application.Loans
{
    public class CreateLoanCommand
    {
        public decimal Amount { get; set; }
        public string CurrencyISOCode{ get; set; }
        public Guid PartyId{ get; set; }
    }
}
