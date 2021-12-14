using System.Threading.Tasks;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;

namespace DiscountAPI.Application.Services
{
    public class InvoiceService : Service<Invoice>, IInvoiceService
    {
        public InvoiceService(IUnitOfWork unitOfWork, IRepository<Invoice> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Invoice> CalculateDiscount(Invoice invoice)
        {
            var getCustomer = await _unitOfWork.Customers.GetByIdAsync(invoice.CustomerId);
            if (getCustomer != null)
            {
            }

            return new Invoice();
        }
    }
}