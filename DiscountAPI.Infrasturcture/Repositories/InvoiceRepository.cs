using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Infrasturcture.Context;

namespace DiscountAPI.Infrasturcture.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}