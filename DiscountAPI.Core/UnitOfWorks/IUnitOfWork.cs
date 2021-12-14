using System.Threading.Tasks;
using DiscountAPI.Core.Repositories;

namespace DiscountAPI.Core.UnitOfWorks
{
  
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }
        IDiscountRepository Discounts { get; }
        ICustomerTypeRepository CustomerTypes { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceProductsRepository InvoiceProducts { get; }
      

        Task CommitAsync();
        void Commit();
    }
}