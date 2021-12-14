using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Infrasturcture.Context;

namespace DiscountAPI.Infrasturcture.Repositories
{
    public class InvoiceProductsRepository : Repository<InvoiceProducts>, IInvoiceProductsRepository
    {
        public InvoiceProductsRepository(AppDbContext appContext) : base(appContext)
        {
        }

        
    }
}