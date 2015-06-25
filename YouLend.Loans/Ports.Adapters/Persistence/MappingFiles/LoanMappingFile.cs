using FluentNHibernate;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLend.Loans.Domain.Model.Loans;

namespace YouLend.Loans.Ports.Adapters.Persistence.MappingFiles
{
    internal class LoanMappingFile : ClassMap<Loan>
    {
        public LoanMappingFile()
        {
            this.Table("Loans");

            this.CompositeId().ComponentCompositeIdentifier<LoanId>(pkk => pkk.LoanId)
                                .KeyProperty(x => x.LoanId.Id, "LoanId");
                          
            //this.Component(c => c.LoanId, m =>
            //{
            //    m.Map(x => x.Id).Column("LoanId");
            //});

            this.Component(c => c.LoanAmount, m =>
            {
                m.Map(x => x.Amount).Column("Amount");
                m.Component(c => c.Currency, p =>
                {
                    p.Map(y => y.IsoCurrencyCode).Column("ISOCurrencyCode");
                    p.Map(y => y.IsoCurrencyName).Column("ISOCurrencyName");
                });
            });
        }
    }
}
