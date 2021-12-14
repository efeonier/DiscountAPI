using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Core.Repositories
{
    public interface IInvoiceProductsRepository : IRepository<InvoiceProducts>
    {
        //Task<IEnumerable<InvoiceProducts>> GetAllByInvoiceIdAsync(int id);
    }
}